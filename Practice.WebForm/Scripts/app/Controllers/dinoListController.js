app.controller('dinoListController', function ($scope, dinoListService) {
    var leftSelection = null; //used to track last selection event for leftSelectDino()
    var rightSelection = null; //used to track last selection event for rightSelectDino()
    var leftDetailSelection = null; //used to track last selection event for detailSelectDino()
    $scope.leftDino = { DinoID: 0, Name: "", Health: 0, Stamina: 0, Oxigen: 0, Weight: 0, Damage: 0 };
    $scope.rightDino = { DinoID: 0, Name: "", Health: 0, Stamina: 0, Oxigen: 0, Weight: 0, Damage: 0 };

    //Define context for the chart
    var chartContext = $('#dinoChart').get(0).getContext('2d');
    var chart = null;

    dinoListService.GetDinos().then(function (response) {
        $scope.detailDinos = response;
        $scope.leftDinos = response;
        $scope.rightDinos = response;
    });

    $scope.leftSelectDino = function ($event) {
        //assign properties to Currently Selected field
        $('#LeftCurrentSelected')
            .text($event.target.innerHTML);
        //parse through selected id and extract number value
        var id = parseInt($event.target.id.replace(/[^0-9\.]/g, ''), 10);
        $('#LeftCurrentSelectedID')
            .val(id);

        //toggle selection class for selected angular object
        $($event.target).css('background-color', '#1a8cff');

        //check for previously clicked selection
        if (leftSelection == null) {
            leftSelection = $event.target.id; //set selection to current selection
        }
        else if (leftSelection == $event.target.id) {
            //change nothing
        }
        else {
            $('#' + leftSelection).css('background-color', 'white'); // toggle css
            leftSelection = $event.target.id; //set selection to current selection
        }

        //set graph data to selection
        dinoListService.GetDinoItem(id)
            .then(function (response) {
                $scope.leftDino = response;
                //call to create graph
                if ($('#LeftCurrentSelectedID').val() > 0 && $('#RightCurrentSelectedID').val() > 0) {
                    GetChart($scope.leftDino, $scope.rightDino);
                }
            });

        return;
    };

    $scope.rightSelectDino = function ($event) {
        //assign properties to Currently Selected field
        $('#RightCurrentSelected')
            .text($event.target.innerHTML);
        //parse through selected id and extract number value
        var id = parseInt($event.target.id.replace(/[^0-9\.]/g, ''), 10);
        $('#RightCurrentSelectedID')
            .val(id);

        //toggle selection class for selected angular object
        $($event.target).css('background-color', '#1a8cff');

        //check for previously clicked selection
        if (rightSelection == null) {
            rightSelection = $event.target.id; //set selection to current selection
        }
        else if (rightSelection == $event.target.id) {
            //change nothing
        }
        else {
            $('#' + rightSelection).css('background-color', 'white'); // toggle css
            rightSelection = $event.target.id; //set selection to current selection
        }

        //set graph data to selection
        dinoListService.GetDinoItem(id)
            .then(function (response) {
                $scope.rightDino = response;
                //call to create graph
                if ($('#LeftCurrentSelectedID').val() > 0 && $('#RightCurrentSelectedID').val() > 0) {
                    GetChart($scope.leftDino, $scope.rightDino);
                }
            });

        return;
    };

    $scope.detailSelectDino = function ($event) {
        //assign properties to Currently Selected field
        $('#LeftCurrentSelectedDetail')
            .text($event.target.innerHTML);
        //parse through selected id and extract number value
        var id = parseInt($event.target.id.replace(/[^0-9\.]/g, ''), 10);
        $('#LeftCurrentSelectedDetailID')
            .val(id);

        //toggle selection class for selected angular object
        $($event.target).css('background-color', '#1a8cff');

        //if something has been selected, load it's data to details page
        if (id != null) {
            dinoListService.GetDinoItem(id)
                .then(function (response) {
                    $scope.selectedDino = response;
                    dinoListService.GetDossier(id)
                        .then(function (image) {
                            $scope.dinoDoss = image;
                        })
                });
        }

        //check for previously clicked selection
        if (leftDetailSelection == null) {
            leftDetailSelection = $event.target.id; //set selection to current selection
        }
        else if (leftDetailSelection == $event.target.id) {
            //change nothing
        }
        else {
            $('#' + leftDetailSelection).css('background-color', 'white'); // toggle css
            leftDetailSelection = $event.target.id; //set selection to current selection
        }

        return;
    };

    //define data to use in chart
    var data = {
        labels: ["Health", "Stamina", "Weight", "Damage"],
        datasets: [
            {
                label: "Left Dino",
                fillColor: "rgba(200,220,220,0.75)",
                strokeColor: "rgba(220,220,220,0.8)",
                highlightFill: "rgba(220,220,220,0.75)",
                highlightStroke: "rgba(220,220,220,1)",
                data: [0, 0, 0, 0]
            },
            {
                label: "Right Dino",
                fillColor: "rgba(151,187,205,0.75)",
                strokeColor: "rgba(151,187,205,0.8)",
                highlightFill: "rgba(151,187,205,0.75)",
                highlightStroke: "rgba(151,187,205,1)",
                data: [0, 0, 0, 0]
            }
        ]
    };

    //define options for given chart type
    var options = {
        //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
        scaleBeginAtZero: true,

        //Boolean - Whether grid lines are shown across the chart
        scaleShowGridLines: true,

        //String - Colour of the grid lines
        scaleGridLineColor: "rgba(0,0,0,.05)",

        //Number - Width of the grid lines
        scaleGridLineWidth: 1,

        //Boolean - Whether to show horizontal lines (except X axis)
        scaleShowHorizontalLines: true,

        //Boolean - Whether to show vertical lines (except Y axis)
        scaleShowVerticalLines: true,

        //Boolean - If there is a stroke on each bar
        barShowStroke: true,

        //Number - Pixel width of the bar stroke
        barStrokeWidth: 2,

        //Number - Spacing between each of the X value sets
        barValueSpacing: 5,

        //Number - Spacing between data sets within X values
        barDatasetSpacing: 1,

        //String - A legend template
        legendTemplate: "<ul class=\"<%=name.toLowerCase()%>-legend\"><% for (var i=0; i<datasets.length; i++){%><li><span style=\"background-color:<%=datasets[i].fillColor%>\"></span><%if(datasets[i].label){%><%=datasets[i].label%><%}%></li><%}%></ul>"

    }

    
    ////Global configurations
    Chart.defaults.global.responsive = true;

    //GetChart
    function GetChart(leftDino, rightDino) {

        data.datasets[0].data = [leftDino.Health, leftDino.Stamina, leftDino.Weight, leftDino.Damage];
        data.datasets[1].data = [rightDino.Health, rightDino.Stamina, rightDino.Weight, rightDino.Damage];

        if (chart == null) {
            chart = new Chart(chartContext).Bar(data, options);
        }
        else {

            ////destroying old chart
            //chart.destroy();

            ////replacing old html canvas with new one
            //$('#dinoChart').replaceWith('<canvas id="dinoChart" style="height: 50vh; width: 100vw;"></canvas>');

            ////creating a new chart context from new canvas
            //var ctx = $('#dinoChart').get(0).getContext('2d');

            ////creating new chart with updated data
            //chart = new Chart(ctx).Bar(data, options);

            chart.datasets[0].bars[0].value = leftDino.Health;
            chart.datasets[0].bars[1].value = leftDino.Stamina;
            chart.datasets[0].bars[2].value = leftDino.Weight;
            chart.datasets[0].bars[3].value = leftDino.Damage;

            chart.datasets[1].bars[0].value = rightDino.Health;
            chart.datasets[1].bars[1].value = rightDino.Stamina;
            chart.datasets[1].bars[2].value = rightDino.Weight;
            chart.datasets[1].bars[3].value = rightDino.Damage;

            chart.update();
        }
        return;
    };
});
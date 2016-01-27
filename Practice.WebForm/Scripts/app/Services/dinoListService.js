app.service('dinoListService', function ($http) {

    this.GetDinos = function () {
        return $http.get("http://localhost:13717/api/Dinos")
                .then(function (response) {
                    return response.data;
                });
    };

    this.GetDinoItem = function (id) {
        return $http.get("http://localhost:13717/api/Dinos/" + id)
                .then(function (response) {
                    return response.data;
                });
    };

    this.GetDossier = function (id) {
        return $http.get("http://localhost:13717/api/Images/" + id)
                .then(function (response) {
                    return response.data;
                });
    };
});
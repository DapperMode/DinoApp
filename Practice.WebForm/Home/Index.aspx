<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Practice.WebForm.Home.Index" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContentLeft">

    <div id="leftContent" class="tab-content">
        <!--Will hold a searchable collection of entities for selection and viewing on bottom pane comparison graph-->
        <div class="stats tab-pane fade in active">
            <div class="row">
                <div class="col-md-6">
                    <label id="LeftCompareFilter" class="">Filter:</label>
                    <input id="LeftCompareSearchValue" ng-model="LeftCompareSearchValue" placeholder="Type here to filter" />
                </div>
                <div class="col-md-6">
                    <label>CurrentSelection:</label>
                    <label id="LeftCurrentSelected"></label>
                    <input type="hidden" value="" id="LeftCurrentSelectedID" />
                </div>
            </div>
            <hr />
            <!--Contains all entities in selectable thumbnails-->
            <div id="LeftCompareEntityPool">
                <div id="{{'left' + dino.DinoID}}" class="col-md-4 panel panel-danger" ng-repeat="dino in leftDinos | filter:LeftCompareSearchValue" ng-click="leftSelectDino($event)">{{dino.Name}}</div>
            </div>
        </div>

        <!--Will contain searchable list of entities for selection and viewing of details on right details pane-->
        <div class="details tab-pane fade">
            <div class="row">
                <div class="col-md-6">
                    <label id="LeftDetailFilter">Filter:</label>
                    <input id="LeftDetailSearchValue" ng-model="LeftDetailSearchValue" placeholder="Type here to filter" />
                </div>
                <div class="col-md-6">
                    <label>CurrentSelection:</label>
                    <label id="LeftCurrentSelectedDetail"></label>
                    <input type="hidden" value="" id="LeftCurrentSelectedDetailID" />
                </div>
            </div>
            <hr />
            <!--Contains all entities in selectable thumbnails -->
            <div id="LeftDetailEntityPool">
                <div id="{{'detail' + dino.DinoID}}" class="col-md-4 panel panel-danger" ng-repeat="dino in detailDinos | filter:LeftDetailSearchValue" ng-click="detailSelectDino($event)">{{dino.Name}}</div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContentRight">
    <div id="rightContent" class="tab-content">

        <!--Will hold a searchable collection of entities for selection and viewing on bottom pane comparison graph-->
        <div class="stats tab-pane fade in active">
            <div class="row">
                <div class="col-md-6">
                    <label id="RightCompareFilter">Filter:</label>
                    <input id="RightCompareSearchValue" ng-model="RightCompareSearchValue" placeholder="Type here to filter" />
                </div>
                <div class="col-md-6">
                    <label>CurrentSelection:</label>
                    <label id="RightCurrentSelected"></label>
                    <input type="hidden" id="RightCurrentSelectedID" value="0" />
                </div>
            </div>
            <hr />
            <!--Contains all entities in selectable thumbnails -->
            <div id="RightCompareEntityPool">
                <div id="{{'right' + dino.DinoID}}" class="col-md-4 panel panel-danger" ng-repeat="dino in rightDinos | filter:RightCompareSearchValue" ng-click="rightSelectDino($event)">{{dino.Name}}</div>
            </div>
        </div>

        <!--Will contain detailed information about selected entity-->
        <div class="details tab-pane fade row">
            <div id="RightSelectedDetailDossier" class="col-md-12">
                <!--where image will reside-->
                <img class="img img-responsive" id="dinoDossImg" src="{{dinoDoss.URL}}" />
            </div>
            <div id="RightSelectedDetailStats" class="col-md-12">
                <ul>
                    <li>
                        <label>Name:</label><span ng-bind="selectedDino.Name"></span></li>
                    <li>
                        <label>Health:</label><span ng-bind="selectedDino.Health"></span></li>
                    <li>
                        <label>Stamina:</label><span ng-bind="selectedDino.Stamina"></span></li>
                    <li>
                        <label>Oxigen:</label><span ng-bind="selectedDino.Oxigen"></span></li>
                    <li>
                        <label>Weight:</label><span ng-bind="selectedDino.Weight"></span></li>
                    <li>
                        <label>Damage:</label><span ng-bind="selectedDino.Damage"></span></li>
                </ul>
            </div>
        </div>

    </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="BottomContent">
    <div id="chartContainer" class="col-md-12">
        <canvas id="dinoChart" style="height: 50vh; width: 100vw"></canvas>
    </div>
</asp:Content>

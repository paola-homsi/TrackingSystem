

function myViewModel() {
    var self = this;
    self.Vehicles = ko.observableArray();
    self.Customers = ko.observableArray();
    self.Status = ko.observableArray();
    self.GetVehicles = function () {
        $.ajax({
            url: 'api/Vehicle',
            type: 'POST',
            success: function (res) {
                self.Vehicles(JSON.parse(res))
            }
        })
    }
    self.GetCustomers = function () {
        $.ajax({
            url: 'api/Customer/GetCustomers',
            type: 'POST',
            success: function (res) {
                self.Customers(JSON.parse(res))
            }
        })
    }
    self.GetStatus = function () {
        $.ajax({
            url: 'api/Status/GetStatuses',
            type: 'POST',
            success: function (res) {
                self.Status(JSON.parse(res))
            }
        })
    }
    self.CustomerChanged = function () {
        id = ($('#CustomerSelect').val())
        url = "/C_api/Vehicle/" + id 
        $.ajax({
            url:  url,
            type: 'POST',
            success: function (res) {
                self.Vehicles(JSON.parse(res))
            }
        })
    }
    self.StatusChanged = function () {
        id = ($('#CustomerSelect').val())
        url = "Status/GetStatusVehicles?id=" + id
        $.ajax({
            url: url,
            type: 'POST',
            success: function (res) {
                self.Vehicles(JSON.parse(res))
            }
        })
    }
    self.GetVehicles();
    self.GetCustomers();
    self.GetStatus();
};


ko.applyBindings(new myViewModel());
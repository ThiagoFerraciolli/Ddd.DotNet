var ViewModel = function () {
    var self = this;
    self.GetClientes = ko.observableArray();
    self.error = {
        Name: ko.observable(),
        CpfCnpj: ko.observable(),
        Phone: ko.observable()
    }
    self.GetUpdate = ko.observable();
    self.newCliente = {
        Name: ko.observable(),
        CpfCnpj: ko.observable(),
        Phone: ko.observable()
    }
    self.btnIncuir = ko.observable();

    var ClienteUri = "/api/Clientes/";

    function AjaxDefault(uri, method, data) {
        self.error.Name('');
        self.error.CpfCnpj('');
        self.error.Phone('');
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error.Name(jqXHR.responseJSON.ModelState["cliente.Name"]);
            self.error.CpfCnpj(jqXHR.responseJSON.ModelState["cliente.CpfCnpj"]);
            self.error.Phone(jqXHR.responseJSON.ModelState["cliente.Phone"]);
        });
    }

    self.IncuirCliente = function () {
        self.btnIncuir(true);
    }

    function GetClientes() {
        AjaxDefault(ClienteUri, 'GET').done(function (data) {
            self.GetClientes(data);
        });
    }

    self.GetUpdateCliente = function (item) {
        AjaxDefault(ClienteUri + item.Id, 'GET').done(function (data) {
            self.GetUpdate(data);
        });
    }

    self.deleteCliente = function (item) {
        AjaxDefault(ClienteUri + item.Id, 'DELETE').done(function (data) {
            self.GetClientes.remove(item);
        });
    }

    self.updateCiente = function (formElement) {
        var cliente = {
            Name: self.GetUpdate().Name,
            CpfCnpj: self.GetUpdate().CpfCnpj,
            Phone: self.GetUpdate().Phone,
            Id: self.GetUpdate().Id
        };
        AjaxDefault(ClienteUri + cliente.Id, 'PUT', cliente).done(function () {
            GetClientes();
            self.GetUpdate('');
        });
    }

    self.addCliente = function (formElement) {
        var cliente = {
            Name: self.newCliente.Name(),
            CpfCnpj: self.newCliente.CpfCnpj(),
            Phone: self.newCliente.Phone()
        };

        AjaxDefault(ClienteUri, 'POST', cliente).done(function (item) {
            self.GetClientes.push(item);
            self.newCliente.Name('');
            self.newCliente.CpfCnpj('');
            self.newCliente.Phone('');
            self.btnIncuir(false);
        });
    }

    self.Cancelar = function () {
        self.btnIncuir(false);
        self.error.Name('');
        self.error.CpfCnpj('');
        self.error.Phone('');
    }
    GetClientes();
};

ko.applyBindings(new ViewModel());
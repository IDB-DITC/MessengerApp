/// <reference path="../lib/microsoft/signalr/dist/browser/signalr.js" />




var username = prompt("enter your name", "DITC");

var hubBuilder = new signalR.HubConnectionBuilder();
var connection = hubBuilder.withUrl("/chathub").build();




connection.on("msgRcv", function (user, message) {
    var a = document.createElement("li");


    a.textContent = `${user} : ${message}`;

    $('#chatLog').html(a);

    
});
connection.on("selfMsg", function ( message) {
    var a = document.createElement("li");


    a.textContent = `(self) : ${message}`;

    //$('#chatLog').append(a);
    $(a).appendTo($('#chatLog'));


});


connection.start();


$('#btnSend').on('click', function () {

    var message = $('#txtInput').val();

    connection.invoke("Share", username, message);
    $('#txtInput').val(null);
})

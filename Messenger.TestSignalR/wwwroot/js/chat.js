"use strict";

//var connection = signalR.HubConnectionBuilder.create("http://localhost:62301/message").build();
var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:62301/message").build();
var t = false;
//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;



connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;


}).catch(function (err) {
    return console.error(err.toString());
});



document.getElementById("sendButton").addEventListener("click", function (event) {
    var sender = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var reciever = document.getElementById("usersend").value;
    //..................................................
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = sender + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
    //................................................
    connection.send("SendMessage", reciever, sender, message).catch(function (err) {
        return console.error(err.toString());
    });
    //connection.invoke("sendmessage",usersend,user, message).catch(function (err) {
    //    return console.error(err.toString());
    //});
    event.preventDefault();

    if (t == false) {
        t = true;
        connection.on(sender, function (sender, message) {
            var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
            var encodedMsg = sender + " says " + msg;
            var li = document.createElement("li");
            li.textContent = encodedMsg;
            document.getElementById("messagesList").appendChild(li);
        });
    }
});
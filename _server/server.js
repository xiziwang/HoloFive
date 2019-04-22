// https://stackoverflow.com/questions/37973081/localhost-says-upgrade-required/38030325#38030325

// Require HTTP module (to start server) and Socket.IO
var app = require('express')(); 
var http = require('http');
var io = require('socket.io');

// Start the server at port 8080
var server = http.createServer(function(req, res){ 

    // Send HTML headers and message
    res.writeHead(200,{ 'Content-Type': 'text/html' }); 
    res.end('<h1>HoloFive Server</h1>');
});
server.listen(8080);


// Create a Socket.IO instance, passing it our server
var socket = io.listen(server);

socket.on('connection', function(client){  
    console.log('Client (' + client.id + ') has connnected');

    // Success!  Now listen to messages to be received
    client.on('message',function(event){ 
        console.log('Received message from HoloLens!');
        console.log(event);
        socket.emit('vibrate', event);
    });

    client.on('disconnect',function (){
        // clearInterval(interval);
        console.log('Client (' + client.id + ') has disconnected');
    });
});

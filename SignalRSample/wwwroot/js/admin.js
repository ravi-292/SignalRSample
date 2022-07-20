"use strict";

let connection = new signalR.HubConnectionBuilder()
    .withUrl("/NotificationHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);//Restart the connection every 5 seconds if issue persists.
    }
};

connection.onclose(async () => {
    await start();
});

connection.on("notificationReceived", (guid, type, title, description) => {
    var heading = document.createElement("h3");
    heading.textContent = title;
    var p = document.createElement("p");
    p.innerText = description;
    var div = document.createElement("div");
    div.appendChild(heading);
    div.appendChild(p);

    document.getElementById("articleList").appendChild(div);
});


// Start the connection.
start();
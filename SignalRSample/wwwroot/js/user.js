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
    var container = document.createElement("div");
    container.className = "alert alert-info alert-dismissible fade show";
    container.role = "alert";

    var titleHtml = document.createElement("h4");
    titleHtml.className = "alert-heading";
    titleHtml.innerText = title;

    var descriptionHtml = document.createElement("p");
    descriptionHtml.innerText = title;

    container.appendChild(titleHtml);
    container.appendChild(descriptionHtml);
    document.getElementById("notification-div").appendChild(container);


//    var alert = `
//<div class="alert alert-warning alert-dismissible fade show" role="alert">
//<h4 class="alert-heading">${title}</h4>
//<p>${description}</p>
//<button type="button" class="close" data-dismiss="alert" aria-label="Close">
//    <span aria-hidden="true">&times;</span>
//</button>
//</div>
//    `;
//    console.log(alert);
//    var template = document.createElement('template');
//    template.innerHTML = alert.trim();
    //document.getElementById("notification-div").appendChild(template);
});


// Start the connection.
start();
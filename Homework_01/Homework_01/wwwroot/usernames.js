let getAllUsersBtn = document.getElementById("get-users-btn");
let usernamesList = document.getElementById("usernames");

let port = "7027";
let getAllUserNames = async () => {
    let url = "https://localhost:" + port + "/api/users";

    let response = await fetch(url);
    console.log(response);
    let usernames = await response.json();
    console.log(usernames);

    for (let i = 0; i < usernames.length; i++) {
        let li = document.createElement("li");
        li.innerText = usernames[i];
        usernamesList.appendChild(li);
    }
}

getAllUsersBtn.addEventListener("click", getAllUserNames);
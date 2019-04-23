function getInput() {
    let username = $("#username").val();
    let password = $("#password").val();
    return {username, password};
}

$("#login-btn").click(function() {
    let {username, password} = getInput();
    var xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function () {
        if (this.readyState === 4) {
            if (this.status == 400) {
                alert(this.responseText);
            }
            if (this.status == 200) {
                window.open("/test", "_self");
            }
        }
    });
    xhr.open("GET", "api/Login/" + username + "/" + password + "/login"); //link to api login
    xhr.send();
});


$("#signup-btn").click(function() {
    let {username, password} = getInput();
    var xhr = new XMLHttpRequest();
    xhr.addEventListener("readystatechange", function () {
        if (this.readyState === 4) {
            if (this.status == 400) {
                alert(this.responseText);
            }
            if (this.status == 200) {
                window.open("/test", "_self");
            }
        }
    });
    xhr.open("GET", "api/Login/" + username + "/" + password + "/create"); //link to api signup
    xhr.send();
});
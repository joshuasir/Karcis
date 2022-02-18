const login = async () => {
    const email = document.getElementById("email").value
    const password = document.getElementById("password").value
    if (email.length == 0 || password.length == 0)
        return alert("Email and password required")
    $("#loginButton").css("visibility", "hidden");

  const requestObject = {
    UserEmail: email,
    UserPassword: password
  }
    const requestjson = JSON.stringify(requestObject)
    const requestQuery = await fetch("../Registry/LoginRequest", {
        method: "POST",
        body: requestjson,
        headers: {
            "Content-Type": "application/json"
        }
    }).catch(err => {
        console.log(err)
        $("#loginButton").css("visibility", "visible");
        return alert("There seems to be an error")
    })
    const responsejson = await requestQuery.json()
    if (!responsejson.status) {
        document.querySelector(".LoginAlert").style.display = "block"
        $("#loginButton").css("visibility", "visible");
        return
    }
  return window.location.replace("/Home")
}
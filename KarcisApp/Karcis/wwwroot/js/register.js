const register = async () => {
    document.querySelector(".Alert").style.display = 'none';
    const name = document.getElementById("name").value
    const birthdate = document.getElementById("birthdate").value
    const phone = document.getElementById("phone").value
    const email = document.getElementById("email").value
    const password = document.getElementById("password").value
    const confirmpassword = document.getElementById("confirmpassword").value

    if (email.length == 0 || password.length == 0 || email === undefined || password === undefined)
        return alert("Email and password required")
    if (password != confirmpassword) {
        document.querySelector(".PasswordAlert").style.display = "block";
    }
    const year = birthdate.split("-")[0]
    const month = birthdate.split("-")[1]
    const day = birthdate.split("-")[2]

    const newdate = `${year}/${month}/${day}`

    $("#registerButton").css("visibility", "hidden");

    const requestObject = {
        UserName: name,
        UserDOB: newdate,
        UserPhone: phone,
        UserEmail: email,
        UserPassword: password
    }
    const requestjson = JSON.stringify(requestObject)
    console.log(requestjson);
    const requestQuery = await fetch("../Registry/SendEmail", {
        method: "POST",
        body: requestjson,
        headers: {
            "Content-Type": "application/json"
        }
    }).catch(err => {
        console.log(err)
        $("#registerButton").css("visibility", "visible");
        return alert("There seems to be an error")
    })


    const responsejson = await requestQuery.json()
    console.log(JSON.stringify(responsejson))
    if (!responsejson.status) {
        document.querySelector(".RegistAlert").style.display = "block";
        $("#registerButton").css("visibility", "visible");
        return
    }
    //window.localStorage.setItem("token", newtoken)
    alert("an email verification link has been sent to your mail!\nPlease verify your mail before logging in")
    return window.location.replace("/Registry/Login");

}
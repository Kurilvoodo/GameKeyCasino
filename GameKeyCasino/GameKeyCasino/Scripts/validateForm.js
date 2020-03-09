var password = document.getElementById("password-signup");
var repeatPassword = document.getElementById("repeat-password-signup");

repeatPassword.addEventListener("input", function (event) {
    if (password.value != repeatPassword.value) {
        repeatPassword.setCustomValidity("Passwords are different");
    }
    else {
        repeatPassword.setCustomValidity("");
    }
});
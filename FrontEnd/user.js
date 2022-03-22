export class User{
    constructor(id,ime,prezime,email,eventi){
    this.id=id;
       this.ime=ime;
       this.prezime=prezime;
       this.email=email;
       this.eventi=eventi;
    }
async getUser () {
    const email = document.getElementById('email').value;
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    const isValidEmail=re.test(String(email).toLowerCase());
    if(!email||!isValidEmail) {
        return "Invalid email";
    }
    const user = await (await fetch(`http://localhost:5000/user/${email}`, { method: 'POST'})).json();
    this.id=user.id;
    this.ime=user.ime;
    this.prezime=user.prezime;
    this.email=user.email;
    this.eventi=user.eventi;
    localStorage.setItem("user",this.id);
    window.location.href="/index.html";
}
async registerUser(){
    const email = document.getElementById("reg-email").value;
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    const isValidEmail=re.test(String(email).toLowerCase());
    if(!email||!isValidEmail) {
        return "Invalid email";
    }
    const ime=document.getElementById("reg-ime").value;
    const prezime =document.getElementById("reg-prezime").value;
    if(!ime||!prezime)
        return;
    const user = await (await fetch(`http://localhost:5000/user`, {
         method: 'POST', 
         body: JSON.stringify({
            Ime:ime,
            Prezime:prezime,
            Email:email
         }
    ),

        headers: {
       'Content-type': 'application/json; charset=UTF-8'
        }
})).json();
    this.id=user.id;
    this.ime=user.ime;
    this.prezime=user.prezime;
    this.email=user.email;
    this.eventi=user.eventi;
    localStorage.setItem("user",this.id);
    window.location.href="/index.html";    
}

crtajMain = () => {
    let regPanel = document.createElement("div");
    regPanel.className = "login-reg-panel";
    document.body.appendChild(regPanel);

    let loginInfoBox = document.createElement("div");
    loginInfoBox.className = "login-info-box";
    regPanel.appendChild(loginInfoBox);

    let loginInfoBoxHeading = document.createElement("h2");
    loginInfoBoxHeading.innerText = "Have an account?";
    loginInfoBox.appendChild(loginInfoBoxHeading);

    let loginLabel = document.createElement("label");
    loginLabel.id = "label-register";
    loginLabel.htmlFor = "log-reg-show";
    loginLabel.innerText = "Login";
    loginInfoBox.appendChild(loginLabel);

    let loginInput = document.createElement("input");
    loginInput.type = "radio";
    loginInput.name = "active-log-panel";
    loginInput.id = "log-reg-show";
    loginInput.checked = "checked";
    loginInfoBox.appendChild(loginInput);

    let regInfoBox=document.createElement("div");
    regInfoBox.className="register-info-box";
    regPanel.appendChild(regInfoBox);

    let regInfoBoxHeading=document.createElement("h2");
    regInfoBoxHeading.innerText="Don't have an account?";
    regInfoBox.appendChild(regInfoBoxHeading);

    let registerLabel=document.createElement("label");
    registerLabel.id="label-login";
    registerLabel.htmlFor="log-login-show";
    registerLabel.innerText="Register";
    regInfoBox.appendChild(registerLabel);

    let registerInput=document.createElement("input");
    registerInput.type="radio"; 
    registerInput.name="active-log-panel";
    registerInput.id="log-login-show";
    regInfoBox.appendChild(registerInput);

    let whitePanel=document.createElement("div");
    whitePanel.className="white-panel";
    regPanel.appendChild(whitePanel);

    let loginShow=document.createElement("div");
    loginShow.className="login-show";
    whitePanel.appendChild(loginShow)

    let loginShowHeading=document.createElement("h2");
    loginShowHeading.innerText="Login";
    loginShow.appendChild(loginShowHeading);

    let loginShowInput1=document.createElement("input");
    loginShowInput1.type="text";
    loginShowInput1.placeholder="Email";
    loginShowInput1.id="email";
    loginShow.appendChild(loginShowInput1);

    let loginShowInput2=document.createElement("input");
    loginShowInput2.type="button";
    loginShowInput2.value="Login";
    loginShowInput2.onclick=this.getUser;
    loginShow.appendChild(loginShowInput2);

    let registerShow=document.createElement("div");
    registerShow.className="register-show";
    whitePanel.appendChild(registerShow);

    let registerShowHeading=document.createElement("h2");
    registerShowHeading.innerText="REGISTER";
    registerShow.appendChild(registerShowHeading);

    let registerShowInput1=document.createElement("input");
    registerShowInput1.type="text";
    registerShowInput1.placeholder="Ime"
    registerShowInput1.id="reg-ime";
    registerShow.appendChild(registerShowInput1);

    let registerShowInput2=document.createElement("input");
    registerShowInput2.type="text";
    registerShowInput2.placeholder="Prezime"
    registerShowInput2.id="reg-prezime";
    registerShow.appendChild(registerShowInput2);

    let registerShowInput3=document.createElement("input");
    registerShowInput3.type="text";
    registerShowInput3.placeholder="Email"
    registerShowInput3.id="reg-email";
    registerShow.appendChild(registerShowInput3);

    let registerShowInput4=document.createElement("input");
    registerShowInput4.type="button";
    registerShowInput4.value="Register";
    registerShowInput4.onclick=this.registerUser;
    registerShow.appendChild(registerShowInput4);

}
}
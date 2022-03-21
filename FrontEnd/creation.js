import { Event } from './event.js';
/*<div class="login-reg-panel">
    <div class="login-info-box">
        <h2>Create Club</h2>
        <label id="label-club" for="log-club-show">Club</label>
        <input type="radio" name="active-club-panel" id="log-club-show"  checked="checked">
    </div>
                        
    <div class="register-info-box">
        <h2>Create Event</h2>
        <label id="label-event" for="log-event-show">Event</label>
        <input type="radio" name="active-club-panel" id="log-event-show">
    </div>
                        
    <div class="white-panel">
        <div class="login-show">
            <h2>Create club</h2>
            <input type="text" placeholder="Ime" />
            <input type="text" placeholder="Adresa" />
            <input type="button" value="Create club">
        </div>
        <div class="register-show">
            <h2>Create event</h2>
            <input type="text" placeholder="Ime" />
            <input type="text" placeholder="Kategorija" />
            <select>
                <option value="klub1">Klub1</option>
                <option value="klub2">Klub2</option>
            </select>
            <select>
                <option value="user1">User1</option>
                <option value="user2">User2</option>
            </select>
            <input type="button" value="Create event">
        </div>
    </div>
</div>*/
let event = new Event();
class Club {
    constructor(ime, adresa) {
        this.ime = ime;
        this.adresa = adresa;
    }


    crtajMain() {
        let regPanel = document.createElement("div");
        regPanel.className = "login-reg-panel";
        document.body.appendChild(regPanel);
    
        let clubInfoBox = document.createElement("div");
        clubInfoBox.className = "login-info-box";
        regPanel.appendChild(clubInfoBox);
    
        let clubInfoBoxHeading = document.createElement("h2");
        clubInfoBoxHeading.innerText = "Create Club";
        clubInfoBox.appendChild(clubInfoBoxHeading);
    
        let clubLabel = document.createElement("label");
        clubLabel.id = "label-club";
        clubLabel.htmlFor = "log-club-show";
        clubLabel.innerText = "Club";
        clubInfoBox.appendChild(clubLabel);
    
        let clubInput = document.createElement("input");
        clubInput.type = "radio";
        clubInput.name = "active-club-panel";
        clubInput.id = "log-club-show";
        clubInput.checked = "checked";
        clubInfoBox.appendChild(clubInput);
    
        let eventInfoBox=document.createElement("div");
        eventInfoBox.className="register-info-box";
        regPanel.appendChild(eventInfoBox);
    
        let eventInfoBoxHeading=document.createElement("h2");
        eventInfoBoxHeading.innerText="Create event";
        eventInfoBox.appendChild(eventInfoBoxHeading);
    
        let eventLabel=document.createElement("label");
        eventLabel.id="label-event";
        eventLabel.htmlFor="log-event-show";
        eventLabel.innerText="Event";
        eventInfoBox.appendChild(eventLabel);
    
        let eventInput=document.createElement("input");
        eventInput.type="radio"; 
        eventInput.name="active-event-panel";
        eventInput.id="log-event-show";
        eventInfoBox.appendChild(eventInput);
    
        let whitePanel=document.createElement("div");
        whitePanel.className="white-panel";
        regPanel.appendChild(whitePanel);
    
        let loginShow=document.createElement("div");
        loginShow.className="login-show";
        whitePanel.appendChild(loginShow)
    
        let loginShowHeading=document.createElement("h2");
        loginShowHeading.innerText="Create Club";
        loginShow.appendChild(loginShowHeading);
    
        let loginShowInput1=document.createElement("input");
        loginShowInput1.type="text";
        loginShowInput1.placeholder="Ime";
        loginShow.appendChild(loginShowInput1);
    
        let loginShowInput2=document.createElement("input");
        loginShowInput2.type="text";
        loginShowInput2.placeholder="Adresa";
        loginShow.appendChild(loginShowInput2);
    
        let loginShowInput3=document.createElement("input");
        loginShowInput3.type="button";
        loginShowInput3.value="Create Club";
        loginShow.appendChild(loginShowInput3);
    
        let registerShow=document.createElement("div");
        registerShow.className="register-show";
        whitePanel.appendChild(registerShow);
    
        let registerShowHeading=document.createElement("h2");
        registerShowHeading.innerText="Create Event";
        registerShow.appendChild(registerShowHeading);
    
        let registerShowInput1=document.createElement("input");
        registerShowInput1.type="text";
        registerShowInput1.placeholder="Ime"
        registerShow.appendChild(registerShowInput1);
    
        let registerShowInput2=document.createElement("input");
        registerShowInput2.type="text";
        registerShowInput2.placeholder="Kategorija"
        registerShow.appendChild(registerShowInput2);
    
        let chooseClub=document.createElement("select");
        registerShow.appendChild(chooseClub);
        let registerShowSelectOption1=document.createElement("option");
        registerShowSelectOption1.value=1;
        registerShowSelectOption1.innerText="Klub1";
        chooseClub.appendChild(registerShowSelectOption1);
    
        let registerShowSelectOption2=document.createElement("option");
        registerShowSelectOption2.value=2;
        registerShowSelectOption2.innerText="Klub2";
        registerShowSelectOption2.selected = true;
        chooseClub.appendChild(registerShowSelectOption2);
    
        const chooseEvent=document.createElement("select");
        registerShow.appendChild(chooseEvent);
    
        let registerShowSelectOption3=document.createElement("option");
        registerShowSelectOption3.value=1;
        registerShowSelectOption3.innerText="User1";
        registerShowSelectOption3.selected = true;
        chooseEvent.appendChild(registerShowSelectOption3);
    
        let registerShowSelectOption4=document.createElement("option");
        registerShowSelectOption4.value=2;
        registerShowSelectOption4.innerText="User2";
        chooseEvent.appendChild(registerShowSelectOption4);
        
        let createEventButton=document.createElement("input");
        createEventButton.type="button";
        createEventButton.value="Create Event";
        createEventButton.onclick = () => event.createEvent(chooseClub.value, registerShowInput1.value, registerShowInput2.value, chooseEvent.value );
        registerShow.appendChild(createEventButton);
    
    }    
}

let club = new Club();
club.crtajMain();
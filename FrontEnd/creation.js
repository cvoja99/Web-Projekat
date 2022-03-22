import { Event } from './event.js';
let event = new Event();
class Club {
    constructor(ime, adresa) {
        this.ime = ime;
        this.adresa = adresa;

    }
    async createClub(ime,adresa){
        if (!ime||!adresa)
            return;
        const club =await ( await fetch(`http://localhost:5000/Klub/`,{
            method:"POST",
            body:JSON.stringify({
                Ime:ime,
                Adresa:adresa
            }),
            headers: {
                'Content-type': 'application/json; charset=UTF-8' 
            } 
        })).json();
        this.id=club.id;
        this.ime=club.ime;
        this.adresa=club.adresa;
        window.location.href = "/index.html";
    }
    async editClub(ime,adresa){
        if (!ime||!adresa)
            return;
        const club = await(await fetcH(`http://localhost:5000/Klub/${this.id}`,{
            method:'PUT',
            body:JSON.stringify({
                Ime: ime || this.ime,
                Adresa:adresa || this.kategorija
            }),
            headers: {
                'Content-type': 'application/json; charset=UTF-8' 
            }  
        })).json();
        this.ime=club.ime;
        this.adresa=club.adresa;
    }
    async deleteClub(){
        const club=await(await fetcH(`http://localhost:5000/Klub/${this.id}`,{
            method:'DELETE',
            })).json();
    }
    async crtajMain() {
        const users= await(await fetch(`http://localhost:5000/User`)).json();
        const clubs= await(await fetch("http://localhost:5000/Klub")).json();
    
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
        eventInput.name="active-club-panel";
        eventInput.id="log-event-show";
        eventInfoBox.appendChild(eventInput);
    
        let whitePanel=document.createElement("div");
        whitePanel.className="white-panel";
        regPanel.appendChild(whitePanel);
    
        let loginShow=document.createElement("div");
        loginShow.className="login-show";
        whitePanel.appendChild(loginShow);
    
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
        loginShowInput3.onclick=()=>club.createClub(loginShowInput1.value,loginShowInput2.value);
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

        for(let i=0;i<clubs.length;i++) {
            let registerShowSelectOption2=document.createElement("option");
            registerShowSelectOption2.value=clubs[i].id;
            registerShowSelectOption2.innerText=clubs[i].ime;
            registerShowSelectOption2.selected = i === 0;
            chooseClub.appendChild(registerShowSelectOption2);
        }
    
        const chooseUser=document.createElement("select");
        registerShow.appendChild(chooseUser);
        for(let i=0;i<users.length;i++) {
            let registerShowSelectOption2=document.createElement("option");
            registerShowSelectOption2.value=users[i].id;
            registerShowSelectOption2.innerText=users[i].ime;
            registerShowSelectOption2.selected = i === 0;
            chooseUser.appendChild(registerShowSelectOption2);
        }
    

        let createEventButton=document.createElement("input");
        createEventButton.type="button";
        createEventButton.value="Create Event";
        createEventButton.onclick = () => event.createEvent(chooseClub.value, registerShowInput1.value, registerShowInput2.value, chooseUser.value );
        registerShow.appendChild(createEventButton);
        $('.login-info-box').fadeOut();
    $('.login-show').addClass('show-log-panel');
    $('.login-reg-panel input[type="radio"]').on('change', function() {
        if($('#log-event-show').is(':checked')) {
            $('.register-info-box').fadeOut(); 
            $('.login-info-box').fadeIn();
            
            $('.white-panel').addClass('right-log');
            $('.register-show').addClass('show-log-panel');
            $('.login-show').removeClass('show-log-panel');
            
        }
        else if($('#log-club-show').is(':checked')) {
            $('.register-info-box').fadeIn();
            $('.login-info-box').fadeOut();
            
            $('.white-panel').removeClass('right-log');
            
            $('.login-show').addClass('show-log-panel');
            $('.register-show').removeClass('show-log-panel');
        }
    }
    
    ); 
    }    
}

let club = new Club();
club.crtajMain();
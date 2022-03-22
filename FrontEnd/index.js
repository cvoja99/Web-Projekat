import { Event } from './event.js';
class Main {
    events = [];
    async getEvents() {
        this.events = [];
        const events = await (await fetch('http://localhost:5000/Event')).json();
        for(let i=0;i<events.length;i++) {
            const event = new Event(events[i].id,events[i].klub,events[i].ime,events[i].kategorija,events[i].izvodjac,events[i].rating || 0);
            await event.averageVotes();
            this.events.push(event);
        }
        const chosenSort = localStorage.getItem('ORDER') || 'ASC';
        this.events.sort((a,b) => chosenSort === 'DESC' ? b.rating - a.rating : a.rating - b.rating);
    }
    async edit(event) {
        
        let ime = prompt("Unesite novo ime",event.ime);
        let kategorija = prompt("Unesite novu kategoriju", event.kategorija);
        if(!ime) {
            alert("Ime ne moze biti prazno");
            return;
        }
        if(!kategorija) {
            alert("kategorija ne moze biti prazno");
            return;
        }
        await event.editEvent(ime, kategorija);
        await this.crtaj();
    }
    async sort(sortOrder) {
        localStorage.setItem('ORDER', sortOrder);
        await this.crtaj();
    }
    Logout(){
        localStorage.removeItem("user")
        window.location.href="/login.html"
    }
    async refresh(event) {
        await event.deleteEvent();
        await this.crtaj();
    }

    async refreshVotes(event, rating) {
            await event.voteForEvent(localStorage.getItem("user")||1, rating);
        
            await this.crtaj();
    }
    async crtaj() {
        document.body.innerHTML = '';
        const chosenSort = localStorage.getItem('ORDER') || 'ASC';
        let navigationPanel=document.createElement("nav");
        navigationPanel.className="navigation";
        document.body.appendChild(navigationPanel);
    
        let ulClass=document.createElement("ul");
        ulClass.className="navigation";
        navigationPanel.appendChild(ulClass);
    
        let list1=document.createElement("li");
        navigationPanel.appendChild(list1);
        
    
        let list2=document.createElement("li");
        navigationPanel.appendChild(list2);
    
        let a2=document.createElement("a");
        a2.href="/creation.html";
        a2.innerText="Create";
        list2.appendChild(a2);
        let list3=document.createElement("li");
        navigationPanel.appendChild(list3);
    
        let list4=document.createElement("li");
        navigationPanel.appendChild(list4);
    
        let b1=document.createElement("button");
        b1.innerText="Logout";
        b1.onclick=this.Logout;
        list4.appendChild(b1);
    
        let containerClass=document.createElement("div")
        containerClass.className="container";
        document.body.appendChild(containerClass);

        const sortOrder = ['ASC', 'DESC'];
        const sort = document.createElement('select');
        sort.value = chosenSort;
        containerClass.appendChild(sort);
        let sortOption1 = document.createElement('option');
        sortOption1.value = sortOrder[0];
        sortOption1.innerText = sortOrder[0];
        sortOption1.selected = chosenSort === 'ASC' && 'selected'
        sort.appendChild(sortOption1);
        let sortOption2 = document.createElement('option');
        sortOption2.value = sortOrder[1];
        sortOption2.innerText = sortOrder[1];
        sortOption1.selected = chosenSort === 'DESC'  && 'selected'
        sort.appendChild(sortOption2);
        const sortBtn = document.createElement('button');
        sortBtn.innerText = "Sort by rating";
        sortBtn.onclick= () => this.sort(sort.value);
        containerClass.appendChild(sortBtn);
        const h2 = document.createElement('h2');
        h2.innerText = "EVENTS";
        containerClass.appendChild(h2);

        await this.getEvents();
    
        for(let i=0; i< this.events.length; i++) {
             
        const wrapper = document.createElement('div');
        wrapper.className = 'card-wrapper';
        containerClass.appendChild(wrapper);

        const h3 = document.createElement('h3');
        h3.innerText ="Ime eventa je: " + this.events[i].ime;
        wrapper.appendChild(h3);

        const div2 = document.createElement('div');
        div2.className = 'event-location';
        div2.innerText = "Kategorija eventa je: " + this.events[i].kategorija;
        wrapper.appendChild(div2);

        
        const imeKluba = document.createElement('h3');
        imeKluba.innerText ="Ime kluba je: " + this.events[i].klub.ime;
        wrapper.appendChild(imeKluba);
        const lokacijaKluba=document.createElement('div');
        lokacijaKluba.innerText="Adresa kluba je: " + this.events[i].klub.adresa
        wrapper.appendChild(lokacijaKluba);
        const imeIzvodjaca = document.createElement('h3');
        imeIzvodjaca.innerText ="Ime izvodjaca je: " + this.events[i].izvodjac.ime + " " + this.events[i].izvodjac.prezime;
        wrapper.appendChild(imeIzvodjaca);
        const kontaktIzvodjaca=document.createElement('div');
        kontaktIzvodjaca.innerText="Email izvodjaca: " + this.events[i].izvodjac.email;
        wrapper.appendChild(kontaktIzvodjaca);  
        const div3 = document.createElement('div');
        div3.className = 'ocena';
        div3.innerText = "Ocena za izvodjaca je: " + this.events[i].rating;
        wrapper.appendChild(div3);

        const deleteBtn = document.createElement('button');
        deleteBtn.innerText = "Delete event";
        deleteBtn.onclick = () => { 
        this.refresh(this.events[i]);
        alert("Event obrisan!");
        }
        wrapper.appendChild(deleteBtn);

        const editBtn=document.createElement('button');
        editBtn.innerText="Edit event";
        editBtn.onclick=()=> {
            this.edit(this.events[i]);
            alert("Event je izmenjen!");}
        wrapper.appendChild(editBtn);
        const voteInput = document.createElement('input');
        voteInput.type = "range";
        voteInput.min = 1;
        voteInput.max = 5;
        wrapper.appendChild(voteInput);

        const voteBtn = document.createElement('button');
        voteBtn.innerText = "Vote";
        voteBtn.onclick = () => {
            this.refreshVotes(this.events[i], voteInput.value);
        }
        wrapper.appendChild(voteBtn);
        }
    }
}

const main = new Main();
main.crtaj();


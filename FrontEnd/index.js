import { Event } from './event.js';
class Main {
    events = [];
    async getEvents() {
        this.events = [];
        const events = await (await fetch('http://localhost:5000/Event')).json();
        for(let i=0;i<events.length;i++) {
            const event = new Event(events[i].id,events[i].klub,events[i].ime,events[i].kategorija,events[i].izvodjac,events[i].rating || 0);
            await event.averageVotes();
            console.log(event);
            this.events.push(event);
        }
    }

    async refresh(event) {
        await event.deleteEvent();
        await this.crtaj();
    }

    async refreshVotes(event, rating) {
        await event.voteForEvent(1, rating);
        await this.crtaj();
    }
    async crtaj() {
        document.body.innerHTML = '';
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
        list4.appendChild(b1);
    
        let containerClass=document.createElement("div")
        containerClass.className="container";
        document.body.appendChild(containerClass);
    
        const h2 = document.createElement('h2');
        h2.innerText = "EVENTS";
        containerClass.appendChild(h2);
        console.log(this.events);

        await this.getEvents();
        console.log(this.events);
        for(let i=0; i< this.events.length; i++) {
             
        const wrapper = document.createElement('div');
        wrapper.className = 'card-wrapper';
        containerClass.appendChild(wrapper);
        const h3 = document.createElement('h3');
        h3.innerText = this.events[i].ime;
        wrapper.appendChild(h3);
        const div2 = document.createElement('div');
        div2.className = 'event-location';
        div2.innerText = this.events[i].kategorija;
        wrapper.appendChild(div2);
        const div3 = document.createElement('div');
        div3.className = 'ocena';
        div3.innerText = this.events[i].rating;
        wrapper.appendChild(div3);
        const deleteBtn = document.createElement('button');
        deleteBtn.innerText = "Delete event";
        deleteBtn.onclick = () => this.refresh(this.events[i]);
        wrapper.appendChild(deleteBtn);
        const voteInput = document.createElement('input');
        voteInput.type = "range";
        voteInput.min = 1;
        voteInput.max = 5;
        wrapper.appendChild(voteInput);
        const voteBtn = document.createElement('button');
        voteBtn.innerText = "Vote";
        voteBtn.onclick = () => this.refreshVotes(this.events[i], voteInput.value);
        wrapper.appendChild(voteBtn);
        }
    }
}

const main = new Main();
main.crtaj();

/* 
  <div class="card-wrapper">
            <h3>Juzni vetar</h3>
            <div class="event-location">Azbresnica</div>
            <div class="ocena">5</div>
        </div>
*/
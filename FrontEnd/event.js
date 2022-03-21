export class Event{
    constructor(id,klub,ime,kategorija,izvodjac,rating){
        this.id=id;
        this.klub=klub;
        this.ime=ime;
        this.kategorija=kategorija;
        this.izvodjac=izvodjac;
        this.rating=rating;
    }
    async createEvent(klub,ime,kategorija,izvodjac){
        console.log({ body:JSON.stringify({
            Ime:ime,
            Kategorija:kategorija
        }),});
      if(!ime||!klub||!kategorija||!izvodjac)
            return;
            try {
      const event = await (await fetch(`http://localhost:5000/Event/${klub}/${izvodjac}`, {  
          method:'POST',
          body:JSON.stringify({
              Ime:ime,
              Kategorija:kategorija
          }),
          headers: {
            'Content-type': 'application/json; charset=UTF-8'   
        }
    })).json();
    this.id=event.id;
    this.klub=event.klub;
    this.ime=event.ime;
    this.kategorija=event.kategorija;
    this.izvodjac=event.izvodjac;
            } catch(e) {
                console.log(e);
            }
    window.location.href = "/index.html";        
}
    async editEvent(ime,kategorija){
     if (!ime&&!kategorija)
        return;
    const event = await (await fetch(`http://localhost:5000/Event/${this.id}`, {  
    method:'PUT',
    body:JSON.stringify({
        Ime: ime || this.ime,
        Kategorija:kategorija || this.kategorija
    }),
        headers: {
        'Content-type': 'application/json; charset=UTF-8'
        }
    })).json();
    this.ime=event.ime;
    this.kategorija=event.kategorija;
}
    async deleteEvent(){
        console.log(this);
        const event = await (await fetch(`http://localhost:5000/Event/${this.id}`,{
            method:'DELETE',
    })).json();
        }
    async voteForEvent(userID,rating){
        console.log(this.id, userID, rating);
        await fetch(`http://localhost:5000/Event/Vote`,{
            method:'POST',
            body:JSON.stringify({
                UserID:userID,
                EventID:this.id,
                Rating:rating
            }),
            headers: {
                'Content-type': 'application/json; charset=UTF-8'
        }
        })
        await this.averageVotes();
    }
    async averageVotes(){
        const rating = await( await fetch(`http://localhost:5000/Event/Vote/${this.id}`)).json();

        this.rating=rating;
    }
    
}
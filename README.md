# ProgettoCSharp2
Ticketitack è un'applicazione realizzata in C# tramite il framework Microsoft.NET che permette di interfacciarsi con un DB, effettuare chiamate
REST su questo tramite PostMan. Inoltre, è possibile visualizzare il contenuto del DB tramite l'interfaccia grafica realizzata in Angular2.

Istruzioni per utilizzare e testare l'applicazione "Ticketitack"

1 - Avviare XAMPP ed abilitare i server Apache e MySQL.

2 - Avviare il progetto denominato "WebApplication1". Si aprirà il Browser e darà un'errore, ignoratelo. Questo progetto contiene la WebAPI, inizializza e crea il database (se questo non è già presente) in ascolto sulla porta 5000. Vengono anche inserite all'interno delle tabelle del DB delle entry di esempio.

3 - E' a questo punto possibile possibile verificare la creazione del DB e delle tabelle usando PhpMyAdmin. E' inoltre possibile interagire con il DB tramite chiamate REST con PostMan. Sono utilizzabili queste
chiamate:
GET http://localhost:5000/api/setup -> per verificare se il DB è stato creato.
GET http://localhost:5000/api/users -> per visualizzare la lista degli Utenti.
GET http://localhost:5000/api/user -> per cercare e visualizzare un Utente tramite Id (specificare Id nel body)
POST http://localhost:5000/api/users -> per aggiornare un Utente (specificare Utente in formato JSON)
PUT http://localhost:5000/api/users -> per inserire un Utente (specificare Utente in formate JSON)
DELETE http://localhost:5000/api/users -> per cancellare un Utente tramite Id (specificare Id nel body)
GET http://localhost:5000/api/concerts -> per visualizzare la lista dei Concerti.
GET http://localhost:5000/api/concert -> per cercare e visualizzare un Concerto tramite Id (specificare Id nel body)
POST http://localhost:5000/api/concerts -> per aggiornare un Concerto (specificare Concerto in formato JSON)
PUT http://localhost:5000/api/concerts -> per inserire un Concerti (specificare Concerto in formate JSON)
DELETE http://localhost:5000/api/concerts -> per cancellare un Concerto tramite Id (specificare Id nel body)

4 - Avviare il progetto denominato "WebApplication2". Si aprirà il Browser che visualizzerà l'interfaccia grafica
di Ticketitack. Tramite l'interfaccia è possibile visualizzare il contenuto dei DB tramite il menù (cliccare su "Our
Customers" visualizzerà la lista degli utenti e cliccare su "Concert List" visualizzerà la lista dei concerti).
ANCORA NON FUNZIONANTE: Nella Home è altresì possibile registrarsi, inserendo un utente nel DB.
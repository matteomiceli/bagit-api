const list = document.getElementById("list");
const newBtn = document.getElementById("btn-new");
const nameText = document.getElementById("name-text");

const connection = new signalR.HubConnectionBuilder()
  .withUrl("https://localhost:7210/listHub")
  .build();

connection
  .start()
  .then(() => {
    console.log("connected");
  })
  .catch((e) => console.log(e));

newBtn.addEventListener("click", (e) => {
  if (nameText.value !== "") {
    connection.invoke("AddItemToList", nameText.value, 1);
  }
});

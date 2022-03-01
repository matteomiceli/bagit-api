let list = document.getElementById("list");
const form = document.getElementById("form");
const newBtn = document.getElementById("btn-new");
const nameText = document.getElementById("name-text");
const deleteBtns = document.getElementsByTagName("li");

const connection = new signalR.HubConnectionBuilder()
  .withUrl("https://localhost:7210/listHub")
  .withAutomaticReconnect()
  .build();

connection
  .start()
  .then(() => {
    console.log("connected");
    // invoke a get all list items function
  })
  .catch((e) => console.log(e));

connection.on("ItemsUpdated", (listArray) => {
  console.log(listArray);
  appendList(listArray);
});

newBtn.addEventListener("click", (e) => {
  if (nameText.value !== "") {
    connection
      .invoke("AddItemToList", nameText.value, "1")
      .catch((e) => console.log(e));
  }
});

function deleteSelf(button) {
  console.log(button.value);
  connection.invoke("RemoveItemFromList", button.value);
}

function appendList(listArray) {
  list.remove();
  list = document.createElement("ul");
  form.appendChild(list);
  listArray.forEach((item) => {
    const li = document.createElement("li");
    li.innerHTML = `${item.name}---<button onclick="deleteSelf(this)" value="${item.name}">X</button>`;
    list.appendChild(li);
  });
}

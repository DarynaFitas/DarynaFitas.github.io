const subjects = [
    { name: "Математика", image: "https://www.englishdom.com/dynamicus/blog-post/000/002/256/1621948173_content_700x455.jpg?1621948173694" },
    { name: "Фізика", image: "https://images.theconversation.com/files/191827/original/file-20171025-25516-g7rtyl.jpg?ixlib=rb-1.1.0&rect=0%2C70%2C7875%2C5667&q=45&auto=format&w=926&fit=clip" },
    { name: "Англійська", image: "https://img.freepik.com/free-vector/english-teacher-concept-illustration_114360-7477.jpg?w=1480&t=st=1684862054~exp=1684862654~hmac=301dfed2fb54cd0409201416b85e7747c933babee5523c10f3db99736b5a6e3b" },
];

function searchSubject() {
    const searchInput = document.getElementById("search").value.toLowerCase();
    const resultDiv = document.getElementById("result");
    resultDiv.innerHTML = "";

    const subject = subjects.find(s => s.name.toLowerCase() === searchInput);
    if (subject) {
        const img = document.createElement("img");
        img.src = subject.image;
        img.alt = subject.name;
        resultDiv.appendChild(img);
    } else {
        resultDiv.textContent = "Такого предмету нема.";
    }
}
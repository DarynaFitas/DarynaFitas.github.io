function checking() {
    const first_number = parseInt(document.getElementById("first-number").value);
    const second_number = parseInt(document.getElementById("second-number").value);
    const answer = parseInt(document.getElementById("user-answer").value);
    const result = document.getElementById('result');

    if (first_number && second_number && answer && (first_number + second_number === answer)) {
        result.textContent = "Correct";
    } else {
        result.textContent = "Wrong";
    }
}
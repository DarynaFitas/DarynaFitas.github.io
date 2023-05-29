class Accounting {
    constructor(code, fullName, position, salary, numOfChildren, experience) {
        this.code = code;
        this.fullName = fullName;
        this.position = position;
        this.salary = salary;
        this.numOfChildren = numOfChildren;
        this.experience = experience;
    }
}

class AccountingCollection {
    constructor() {
        this.items = [];
    }

    add(accounting) {
        this.items.push(accounting);
    }

    addRange(accountings) {
        this.items.push(...accountings);
    }

    edit(code, newData) {
        const index = this.findIndexByCode(code);
        if (index !== -1) {
            Object.assign(this.items[index], newData);
        }
    }

    remove(code) {
        const index = this.findIndexByCode(code);
        if (index !== -1) {
            this.items.splice(index, 1);
        }
    }

    getOne(code) {
        const index = this.findIndexByCode(code);
        return index !== -1 ? this.items[index] : null;
    }

    getFilteredByPositionAndChildrenCount(position, numOfChildren) {
        return this.items.filter(
            (accounting) =>
                accounting.position === position &&
                accounting.numOfChildren <= numOfChildren
        );
    }

    findIndexByCode(code) {
        return this.items.findIndex((accounting) => accounting.code === code);
    }
}

const employees = new AccountingCollection()
function addEmployee() {
    const code = document.getElementById("Код").value;
    const name = document.getElementById("ПІБ").value;
    const position = document.getElementById("Посада").value;
    const salary = document.getElementById("Заробітня плата").value;
    const children = document.getElementById("Кількість дітей").value;
    const experience = document.getElementById("Стаж").value;

    const employee = new Accounting(code, name, position, salary, children, experience);

    employees.add(employee)

    alert(`Додано співробітника:\nКод: ${code}\nПІБ: ${name}\nПосада: ${position}\nЗарплата: ${salary}\nКількість дітей: ${children}\nСтаж: ${experience}`);
}

function getEmployee() {
    const code = document.getElementById("code").value;
    const employee = employees.getOne(code);
    if (employee) {
        alert(`Код: ${employee.code}, ПІБ: ${employee.fullName}, Посада: ${employee.position}, Заробітна плата: ${employee.salary}, Кількість дітей: ${employee.childrenCount}, Стаж: ${employee.experience}`);
    } 
    else {
        alert("Співробітника з таким кодом не знайдено!");
    }
}


function editEmployee() {
    const code = document.getElementById("code").value;
    const employee = employees.getOne(code);
    if (employee) {
        const fullName = prompt("Введіть нове ПІБ:", employee.fullName);
        const position = prompt("Введіть нову посаду:", employee.position);
        const salary = prompt("Введіть нову заробітну плату:", employee.salary);
        const childrenCount = prompt("Введіть нову кількість дітей:", employee.childrenCount);
        const experience = prompt("Введіть новий стаж:", employee.experience);

        employee.fullName = fullName || employee.fullName;
        employee.position = position || employee.position;
        employee.salary = salary || employee.salary;
        employee.childrenCount = childrenCount || employee.childrenCount;
        employee.experience = experience || employee.experience;

        alert("Інформацію про співробітника успішно відредаговано!");
    } else {
        alert("Співробітника з таким кодом не знайдено!");
    }
}


function deleteEmployee() {
    const code = document.getElementById("code").value;
    const index = employees.findIndexByCode(code);
    if (index !== -1) {
        employees.remove(index);
        alert("Інформацію про співробітника успішно видалено!");
    } else {
        alert("Співробітника з таким кодом не знайдено!");
    }
}

function getFilteredEmployees() {
    const position = document.getElementById("position-filter").value;
    const children = parseInt(document.getElementById("children-filter").value);

    const filteredEmployees = employees.getFilteredByPositionAndnumOfChildren(position, children);

    if (filteredEmployees.length > 0) {
        let result = "Список співробітників:\n\n";
        filteredEmployees.forEach(employee => {
            result += `Код: ${employee.code}, ПІБ: ${employee.fullName}, Посада: ${employee.position}, Заробітна плата: ${employee.salary}, Кількість дітей: ${employee.childrenCount}, Стаж: ${employee.experience}\n\n`;
        });
        alert(result);
    } else {
        alert("Не знайдено жодного співробітника за вказаними критеріями.");
    }
}

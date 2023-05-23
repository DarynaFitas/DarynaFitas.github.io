function Accountant(code, fullName, position, salary, numOfChildren, experience) {
    this.code = code;
    this.fullName = fullName;
    this.position = position;
    this.salary = salary;
    this.numOfChildren = numOfChildren;
    this.experience = experience;

    this.getInfo = function() {
        console.log(`Код: ${this.code}, ПІБ: ${this.fullName}, Посада: ${this.position}, ЗП: ${this.salary}, Кількість дітей: ${this.numOfChildren}, Стаж: ${this.experience}`);
    }
}

const accountant1 = new Accountant(1, "Симоненко Наталія Володимирівна", "Головний бухгалтер", 15000, 0, 15);
const accountant2 = new Accountant(2, "Ільтьо Марія Сергіївна", "Старший бухгалтер", 7800, 12, 7);
const accountant3 = new Accountant(3, "Кривка Юлія Олександрівна", "Бухгалтер", 4850, 4, 5);

accountant1.getInfo();
accountant2.getInfo();
accountant3.getInfo();
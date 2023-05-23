function Company(code, name, employees, industry, address) {
    this.code = code;
    this.name = name;
    this.employees = employees;
    this.industry = industry;
    this.address = address;

    this.getInfo = function() {
        console.log(`Код: ${this.code}; Назва: ${this.name}; Кількість співробітників: ${this.employees}; Галузь: ${this.industry}; Адреса: ${this.address}`);
    }
}
const company1 = new Company(10, "FD Company", 1160, "Магазин косметичних товарів", "вул. Заньковецька, 2А");
company1.getInfo(); 
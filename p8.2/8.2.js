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

    getFilteredByPositionAndnumOfChildren(position, numOfChildren) {
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


const accountingCollection = new AccountingCollection();
accountingCollection.add(
    new Accounting("4", "Олексик Сергій Андрійович", "молодший Бухгалтер", 3590, 3, 1)
);
accountingCollection.add(
    new Accounting("5", "Підгорівка Ксенія Володимирівна", "Бухгалтер", 5500, 9, 3)
);
accountingCollection.add(
    new Accounting("6", "Кривецько Назар Савович", "Помічник старшого Бухгалтера", 9400, 0, 6)
);

accountingCollection.edit("4", { salary: 3000 });
accountingCollection.edit("5", { salary: 4500 });
accountingCollection.edit("6", { salary: 6000 });

accountingCollection.remove("4");
accountingCollection.remove("5");
accountingCollection.remove("6");

const accounting4 = accountingCollection.getOne("4");
const accounting5 = accountingCollection.getOne("5");
const accounting6 = accountingCollection.getOne("6");
console.log(accounting);

const filtered4 = accountingCollection.getFilteredByPositionAndnumOfChildren( "молодший Бухгалтер", 3);
const filtered5 = accountingCollection.getFilteredByPositionAndnumOfChildren( "Бухгалтер", 9);
const filtered6 = accountingCollection.getFilteredByPositionAndnumOfChildren( "Помічник старшого Бухгалтера", 0);
console.log(filtered);
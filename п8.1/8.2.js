function DAI(code, ownerName, carBrand, carNumber, carColor) {
    this.code = code;
    this.ownerName = ownerName;
    this.carBrand = carBrand;
    this.carNumber = carNumber;
    this.carColor = carColor;

    this.getInfo = function() {
        console.log('Код: ${this.code}; Власник: ${this.ownerName}; Марка авто: ${this.carBrand}; Номер авто: ${this.carNumber}; Колір авто: ${this.carColor}');
    }
}
const dai1 = new DAI(10, "Ільтьо Марія Сергіївна", "Maserati", "AO8888АС", "чорний");
const dai2 = new DAI(11, "Мац Михайло Олександрович", "Tavria", "AO9753АС", "сірий");
const dai3 = new DAI(12, "Конрятин Олексій Тарасович", "Skoda", "AO9934АС", "червоний");
dai1.getInfo(); 
dai2.getInfo(); 
dai3.getInfo(); 
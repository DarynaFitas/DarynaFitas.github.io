<?php

$center = [
    'code' => null,
    'name' => null,
    'gender' => null,
    'birth_year' => null,
    'education' => null,
    'specialty' => null,
    'registration_date' => null,
];

$jobCenter = [
    [
        'code' => 1,
        'name' => 'Іван',
        'gender' => 'чоловік',
        'birth_year' => 1955,
        'education' => 'вища',
        'specialty' => 'інженер',
        'registration_date' => '2023-01-15',
    ],
    [
        'code' => 2,
        'name' => 'ХЕХ',
        'gender' => 'жінка',
        'birth_year' => 1960,
        'education' => 'середня',
        'specialty' => 'лікар',
        'registration_date' => '2022-11-20',
    ],
    [
        'code' => 2,
        'name' => 'Оля',
        'gender' => 'жінка',
        'birth_year' => 1960,
        'education' => 'середня',
        'specialty' => 'лікар',
        'registration_date' => '2022-11-20',
    ],
    [
        'code' => 2,
        'name' => 'Яна',
        'gender' => 'жінка',
        'birth_year' => 1960,
        'education' => 'середня',
        'specialty' => 'лікар',
        'registration_date' => '2022-11-20',
    ],
    [
        'code' => 2,
        'name' => 'Жижа',
        'gender' => 'жінка',
        'birth_year' => 1960,
        'education' => 'середня',
        'specialty' => 'лікар',
        'registration_date' => '2022-11-20',
    ],
    [
        'code' => 3,
        'name' => 'Марина',
        'gender' => 'жінка',
        'birth_year' => 1990,
        'education' => 'вища',
        'specialty' => 'економіст',
        'registration_date' => '2023-03-10',
    ],
];

$pensionAgeMale = 65;
$pensionAgeFemale = 60;

$filteredJobCenter = [];

foreach ($jobCenter as $person) {
    $currentYear = date("Y");
    $age = $currentYear - $person['birth_year'];

    if (($person['gender'] === 'чоловік' && $age >= $pensionAgeMale) ||
        ($person['gender'] === 'жінка' && $age >= $pensionAgeFemale)) {
        $filteredJobCenter[] = $person;
    }
}
$errors = [];

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $editedIndex = $_POST['edited_index'] ?? -1;
    $editedJobCenter = $jobCenter[$editedIndex] ?? null;


    if (empty($_POST['education'])) {
        $errors['education'] = 'Поле "education" не може бути порожнім';
    }


    if (!is_numeric($_POST['birth_year']) || ($_POST['birth_year'] < 0)) {
        $errors['birth_year'] = 'Поле "birth_year" повинно бути невідємним числом';
    }

    if (empty($errors)) {
        if ($editedJobCenter !== -1) {
            $jobCenter[$editedIndex] = [
                'code' => $_POST['code'],
                'name' => $_POST['name'],
                'gender' => $_POST['gender'],
                'birth_year' => $_POST['birth_year'],
                'education' => $_POST['education'],
                'specialty' => $_POST['specialty'],
                'registration_date' => $_POST['registration_date'],
            ];
        }
    }
}

$searchedJobCenter = null;
$searchedCode = $_GET['search_code'] ?? null;

if ($searchedCode !== null) {
    foreach ($jobCenter as $center) {
        if ($center['code'] == $searchedCode) {
            $searchedJobCenter = $center;
            break;
        }
    }
}


$jobCenter = array_filter($jobCenter,function ($element){
    $birth = $_GET['birth_year'] ?? null;

    if(!empty($birth) && $element['birth_year'] < $birth){
        //return true;
        return false;
    }
    //return false;
    return true;
});
?>

<table border="1">
    <thead>
    <th>Code</th>
    <th>Name</th>
    <th>Gender</th>
    <th>Birth_year</th>
    <th>Education</th>
    <th>Specialty</th>
    <th>Reg_date</th>
    </thead>
    <?php foreach ($jobCenter as $key => $center): ?>
    <tr>
        <td><?= $center['code']; ?></td>
        <td><?= $center['name']; ?></td>
        <td><?= $center['gender']; ?></td>
        <td><?= $center['birth_year']; ?></td>
        <td><?= $center['education']; ?></td>
        <td><?= $center['specialty']; ?></td>
        <td><?= $center['registration_date']; ?></td>
        <td>


            <form method="POST" action="">
                <input type="hidden" name="delete_index" value="<?= $key; ?>">
                <button type="submit">Видалити</button>
            </form>
        </td>
    </tr>
    <?php endforeach; ?>
</table>

    <form method="GET" action="">
        <label for="search_code">Пошук за кодом:</label>
        <input type="text" id="search_code" name="search_code">
        <button type="submit">Пошук</button>
    </form>
<?php if ($searchedJobCenter !== null): ?>
    <h2>Результат пошуку:</h2>
    <table border="1">
        <thead>
        <th>Code</th>
        <th>Adress</th>
        <th>Firma</th>
        <th>Litre</th>
        <th>Fuel</th>
        <th>Price</th>
        <th>Actions</th>
        </thead>
        <tr>
            <td><?= $searchedJobCenter['code']; ?></td>
            <td><?= $searchedJobCenter['name']; ?></td>
            <td><?= $searchedJobCenter['gender']; ?></td>
            <td><?= $searchedJobCenter['birth_year']; ?></td>
            <td><?= $searchedJobCenter['education']; ?></td>
            <td><?= $searchedJobCenter['specialty']; ?></td>
            <td><?= $searchedJobCenter['registration_date']; ?></td>
            <td>
                <form method="POST" action="">
                    <input type="hidden" name="edited_index" value="<?= $searchedJobCenter['code']; ?>">
                    <button type="submit">Редагувати</button>
                </form>
            </td>
        </tr>
    </table>
<?php endif; ?>



    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Редагування об'єкта</title>
    </head>
    <body>
    <h1>Редагування об'єкта</h1>
    <form method="post" action="">
        <input type="hidden" name="edited_index" value="<?= $editedIndex; ?>">

        <label for="code">Код:</label>
        <input type="text" id="code" name="code" value="<?= htmlspecialchars($editedJobCenter['code'] ?? ''); ?>"><br>

        <label for="name">Name:</label>
        <input type="text" id="name" name="name" value="<?= htmlspecialchars($editedJobCenter['name'] ?? ''); ?>"><br>

        <label for="gender">Gender:</label>
        <input type="text" id="gender" name="gender" value="<?= htmlspecialchars($editedJobCenter['gender'] ?? ''); ?>"><br>

        <label for="birth_year">Birth_year:</label>
        <input type="text" id="birth_year" name="birth_year" value="<?= htmlspecialchars($editedJobCenter['birth_year'] ?? ''); ?>">
        <?php if (!empty($errors['birth_year'])): ?>
            <p class="error"><?= $errors['birth_year']; ?></p>
        <?php endif; ?>
        <br>
        <label for="education">Education:</label>
        <input type="text" id="education" name="education" value="<?= htmlspecialchars($editedJobCenter['education'] ?? ''); ?>">
        <?php if (!empty($errors['education'])): ?>
            <p class="error"><?= $errors['education']; ?></p>
        <?php endif; ?>
        <br>
        <label for="specialty">Specialty:</label>
        <input type="text" id="specialty" name="specialty" value="<?= htmlspecialchars($editedJobCenter['specialty'] ?? ''); ?>"><br>
        <label for="registration_date">Reg_date:</label>
        <input type="text" id="registration_date" name="registration_date" value="<?= htmlspecialchars($editedJobCenter['registration_date'] ?? ''); ?>"><br>


        <button type="submit" name="submit">Зберегти зміни</button>
    </form>


    </body>
    </html>

<?php
function saveAndSerializeDataa($data) {
    $serialized_data = serialize($data);

    if (file_put_contents('data.txt', $serialized_data) !== false) {
        return true;
    } else {
        return false;
    }
}

$jobCenter = [];

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (isset($_POST['save'])) {

        $code = $_POST['code'];
        $name = $_POST['name'];
        $gender = $_POST['gender'];


        $new_entry1 = [
            'code' => $code,
            'name' => $name,
            'gender' => $gender,
        ];


        $jobCenter[] = $new_entry1;}


    if (saveAndSerializeDataa($jobCenter)) {
        echo 'Дані збережено успішно.';
    } else {
        echo 'Помилка під час збереження даних.';
    }
}


?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Форма для збереження даних</title>
</head>
<body>
<h1>Форма для збереження даних</h1>
<form method="POST" action="">

    <label for="code">code:</label>
    <input type="text" id="code" name="code" placeholder="Введіть code" required><br>
    <label for="name">name:</label>
    <input type="text" id="name" name="name" placeholder="Введіть name" required><br>


    <label for="gender">gender:</label>
    <input type="text" id="gender" name="gender" placeholder="Введіть gender" required><br>


    <input type="submit" name="save" value="Зберегти дані">
</form>
</body>
</html>
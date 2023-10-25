<!--*2. (20 балів) На сервері зберігається список Предметів (Id, Назва, Викладач,
//Кількість балів). Розробити Web сторінку для перегляду всього списку
//предметів. Розмістити поле з для вводу прохідного балу. При натисканні
//відповідної кнопки показати тільки список предметів з яких отримано не
//меншу кількість балів ніж прохідний.
3. (10 балів) Реалізувати завдання 2 зі збереженням даних в CSV файлі.-->

<?php

function loadSubjectsFromJSON()
{
    $jsonFile = 'id.json';
    if (file_exists($jsonFile)) {
        $jsonData = file_get_contents($jsonFile);
        return json_decode($jsonData, true);
    } else {
        return [];
    }
}

function filterSubjectsByGrade($subjects, $passingGrade)
{
    $filteredSubjects = [];
    foreach ($subjects as $subject) {
        if ($subject['points'] >= $passingGrade) {
            $filteredSubjects[] = $subject;
        }
    }
    return $filteredSubjects;
}

$subjects = loadSubjectsFromJSON();

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $passingGrade = (int)$_POST['passing_grade'];
    $filteredSubjects = filterSubjectsByGrade($subjects, $passingGrade);
}

?>

<!DOCTYPE html>
<html>
<head>
    <title>Список предметів</title>
</head>
<body>
<form method="POST">
    <label for="passing_grade">Введіть прохідний бал:</label>
    <input type="text" name="passing_grade" id="passing_grade">
    <input type="submit" value="Фільтрувати">
</form>

<table>
    <tr>
        <th>Id</th>
        <th>Назва</th>
        <th>Викладач</th>
        <th>Кількість балів</th>
    </tr>
    <?php
    if (isset($filteredSubjects)) {
        foreach ($filteredSubjects as $subject) {
            echo '<tr>';
            echo '<td>' . $subject['id'] . '</td>';
            echo '<td>' . $subject['name'] . '</td>';
            echo '<td>' . $subject['teacher'] . '</td>';
            echo '<td>' . $subject['points'] . '</td>';
            echo '</tr>';
        }
    }
    ?>
</table>
</body>
</html>




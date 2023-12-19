SELECT * FROM Kafedra WHERE surname LIKE 'Іва%';
SELECT * FROM Kafedra WHERE classroom IS NULL;
SELECT * FROM Kafedra WHERE position IN ('Доцент', 'Професор');
SELECT * FROM Kafedra WHERE classroom BETWEEN 100 AND 200;

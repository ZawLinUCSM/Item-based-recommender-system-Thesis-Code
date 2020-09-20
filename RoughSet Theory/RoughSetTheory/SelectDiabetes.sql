SELECT 'DB' As Attribute,Patients FROM DecisionTable
WHERE Diabetes=2
Union ALL
SELECT 'DB' AS Attribute,Patients FROM DecisionTable
WHERE Diabetes=1

SELECT Patients FROM DecisionTable
WHERE Tiredness=2

SELECT Patients FROM DecisionTable
WHERE Tiredness=1

SELECT Patients FROM DecisionTable
WHERE WeightLoss=2

SELECT Patients FROM DecisionTable
WHERE WeightLoss=1

SELECT Patients FROM DecisionTable
WHERE FrequentUrination=2

SELECT Patients FROM DecisionTable
WHERE FrequentUrination=1

SELECT Patients FROM DecisionTable
WHERE Hunger=2

SELECT Patients FROM DecisionTable
WHERE Hunger=1


SELECT Patients FROM DecisionTable
WHERE Thirst=2

SELECT Patients FROM DecisionTable
WHERE Thirst=1




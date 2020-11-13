-- 1.   >show autocommit; OFF
-- 2.
UPDATE duvernay.mespays SET HEAD_OF_STATE = 'Donald J. Trump' WHERE UPPER(NAME)='UNITED STATES';
-- 3. non
-- 4. CA BLOQUE
-- 5. NON PLUS
-- 6.
UPDATE mespays SET HEAD_OF_STATE = 'Dilma Rousseff' WHERE UPPER(name)='BRAZIL';
-- ca marche

-- 12.
UPDATE mespays SET LIFE_EXPECTANCY = (LIFE_EXPECTANCY + 2) WHERE UPPER(NAME)='UNITED STATES';
-- 14. 79.1 dans les deux sessions
-- 15. 77.1 dans les deux sessions

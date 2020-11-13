--1. Les triggers entraînent-ils une validation automatique

-- non. (d'après le corrigé)

--2. Ecrire un trigger TrigSupEmp qui se déclenche après la suppression d'un
--   employé. Le trigger affiche alors le message "Employé numéro empno
--   supprimé". Si cet employé est responsable hiérarchique d'autres employés,
--   les employés concernés se retrouvent sans responsable et un message
--   affiche leurs numéros.
--   Est-ce que :NEW est défini après une suppression ? Testez.
--   Que se passe-t-il ? Modifiez le trigger pour le faire fonctionner au
--   moins en partie.

-- un trigger réalisant tous les traitements de l'énoncé ne peut
--  fonctionner en raison du SELECT et du UPDATE sur une table
--  en cours de DELETE

SET SERVEROUTPUT ON;
CREATE OR REPLACE TRIGGER TrigSupEmp BEFORE DELETE ON emp FOR EACH ROW
BEGIN
    DBMS_OUTPUT.PUT_LINE('Employé numéro' || :OLD.empno || 'supprimé');
END;
/

--3. Ecrire un trigger TrigQuotaSub qui se déclenche en cas
--   d'insertion d'un nouvel employé et affectation comme  subordonné
--   à un responsable hiérarchique, et qui affiche un message d'alerte si
--   le responsable encadre plus de 4 employés. Testez.

SET SERVEROUTPUT ON;
CREATE OR REPLACE TRIGGER TrigQuotaSub AFTER INSERT OR UPDATE OF mgr ON emp FOR EACH ROW
DECLARE
    nbSub NUMBER;
BEGIN
    SELECT count(*) INTO nbSub FROM emp WHERE mgr = :NEW.mgr;
    IF(nbSub>4) THEN
        DBMS_OUTPUT.PUT_LINE('Attention : l"employé' || :NEW.mgr || 'a' || nbSub || 'subordonnées');
    END IF;
END;
/

-- table en mutation donc marche pas

SET SERVEROUTPUT ON;
CREATE OR REPLACE TRIGGER TrigQuotaSub BEFORE INSERT ON emp FOR EACH ROW WHEN (NEW.mgr IS NOT NULL)
DECLARE
    nbSub NUMBER;
BEGIN
    SELECT count(*) INTO nbSub FROM emp WHERE mgr=:NEW.mgr;

    IF (nbSub>4) THEN 
        DBMS_OUTPUT.PUT_LINE(('Attention : l''employé ' || :NEW.mgr || ' a ' || nbSub || 'subordonnés');
    END IF;
END;
/


--4. Désactivez ce trigger : ALTER TRIGGER TrigQuotaSub DISABLE
--   Testez puis réactivez le.



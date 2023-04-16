/**
 *  @author Vincenzo Salvati - vincenzosalvati@hotmail.it
 *
 *  @file Init Database.sql
 *
 *  @brief Init Database.
 *
 *  Generate tables, users and triggers.
 */

USE englishdictionaryschema;

DROP USER IF EXISTS 'viewer'@'localhost';
CREATE USER 'viewer'@'localhost' IDENTIFIED BY '1234';

DROP TABLE IF EXISTS word;
DROP TABLE IF EXISTS phrase;
DROP TABLE IF EXISTS category;

CREATE TABLE category (
    id INT AUTO_INCREMENT PRIMARY KEY,
    isWord BOOLEAN UNIQUE NOT NULL
);

CREATE TABLE phrase (
    id INT AUTO_INCREMENT PRIMARY KEY,
    englishPhrase VARCHAR(255) UNIQUE NOT NULL,
    italianPhrase VARCHAR(255) NOT NULL,
    categoryId INT,
    FOREIGN KEY (categoryId)
        REFERENCES category (id)
);

CREATE TABLE word (
    id INT AUTO_INCREMENT PRIMARY KEY,
    englishWord VARCHAR(255) UNIQUE NOT NULL,
    italianWord VARCHAR(255) NOT NULL,
	isAdjective BOOLEAN NOT NULL DEFAULT FALSE,
    isVerb BOOLEAN NOT NULL DEFAULT FALSE,
    categoryId INT,
    FOREIGN KEY (categoryId)
        REFERENCES category (id)
);

GRANT SELECT ON word TO 'viewer'@'localhost';
GRANT SELECT ON phrase TO 'viewer'@'localhost';

DROP TRIGGER IF EXISTS prevent_both_true_insert;
DROP TRIGGER IF EXISTS prevent_both_true_update;
DROP PROCEDURE IF EXISTS raise_error;

DELIMITER //
CREATE TRIGGER prevent_both_true_insert
BEFORE INSERT ON word
FOR EACH ROW
BEGIN
    IF NEW.isAdjective = TRUE AND NEW.isVerb = TRUE THEN
        CALL raise_error('Both boolean attributes cannot be true');
    END IF;
END//
DELIMITER ;


DELIMITER //
CREATE TRIGGER prevent_both_true_update
BEFORE UPDATE ON word
FOR EACH ROW
BEGIN
    IF NEW.isAdjective = TRUE AND NEW.isVerb = TRUE THEN
        CALL raise_error('Both boolean attributes cannot be true');
    END IF;
END//
DELIMITER ;

DELIMITER //
CREATE PROCEDURE raise_error(error_message VARCHAR(255))
BEGIN
	SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = error_message;
END//
DELIMITER ;

INSERT INTO category (isWord) VALUES(false);
INSERT INTO category (isWord) VALUES(true);
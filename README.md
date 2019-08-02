# WCFRestFul_Postulant

README

Il faut moidifier!!!

Pour le projet: 

Client_PostePostulant il faut modifier les classes:
	ClientCandidate
	l'attribut, selon le port que votre machine dessigne
		private static readonly string urlCandidate = "http://localhost:51034/Service.svc";
	ClientJob
	l'attribut, selon le port que votre machine dessigne
		private static readonly string urlJob = "http://localhost:43741/WRestFul_Poste/webresources/service";

WCFRestFul_Postulant il faut modifier la classe 
	DataManager dans la methode Get()
	l'attribut qui designe le path de l'emplacement du fichier Postulantdb.mdf
        string pathPostulantdb = "C:\\Users\\Judith\\Documents\\H@BDEB3\\Services\\Rest\\Postes_Postulants\\WCFRestFul_Postulant\\WCFRestFul_Postulant\\App_Data\\"+ nomBD;
	
	La DB se trouve dans le dossier du projet 
		\\Postes_Postulants\\WCFRestFul_Postulant\\WCFRestFul_Postulant\\App_Data\\Postulantdb.mdf

WRestFul_Poste il faut modifier dans le package com.latino.utilitarie la classe 
	DataManager l'attribut
	    private static final String url = "jdbc:mysql://localhost:3306/postesdb?useSSL=false";
	Le fichier SQL pour la generation de BD poste se trouve dans le dossier 
		\Postes_Postulants\WRestFul_Poste\SQLDataBase\postesdb.sql
	
	

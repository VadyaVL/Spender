import 'dart:async';
import 'dart:io';

import 'package:path/path.dart';
import 'package:path_provider/path_provider.dart';
import 'package:sqflite/sqflite.dart';

/*
CREATE TABLE category(
  id    	INTEGER PRIMARY KEY, 
  title 	TEXT
);
CREATE TABLE job(
  id     	INTEGER,
  startDate   	TEXT, 
  endDate   	TEXT, 
  categoryId 	INTEGER,
  FOREIGN KEY(categoryId) REFERENCES category(id)
);
*/

final String dbFileName = "spender.db";
final String dbCreateScript = "CREATE TABLE $tableCategory($columnId INTEGER PRIMARY KEY, $columnTitle TEXT); CREATE TABLE $tableJob($columnId INTEGER, $columnStartDate TEXT,  $columnEndDate TEXT,  $columnFKCategory INTEGER, FOREIGN KEY($columnFKCategory) REFERENCES $tableCategory($columnId));";

final String tableCategory = "category";
final String tableJob = "job";

final String columnId = "_id";
final String columnTitle = "title";
final String columnStartDate = "startDate";
final String columnEndDate = "endDate";
final String columnFKCategory = "categoryId";

Future<Database> getDataBaseAsync() async {
  return await getDataBaseByFileNameAsync(dbFileName);
}

Future<Database> getDataBaseByFileNameAsync(String dbName) async {
  Directory documentsDirectory = await getApplicationDocumentsDirectory();
  String path = join(documentsDirectory.path, dbName);

  return await openDatabase(path, version: 1,
      onCreate: (Database db, int version) async {
        await db.execute(dbCreateScript);
  });
}
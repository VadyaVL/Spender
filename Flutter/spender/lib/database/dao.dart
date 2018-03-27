import 'dart:async';

import 'database.dart';
import 'models.dart';

class Dao {
  CategoryRepository categoryRepository;

  Dao() {
    this.categoryRepository = new CategoryRepository();
  }
}

abstract class Repository<T>  {
  Future<List<T>> getAll();
  Future<T> insert(T object);
}

class CategoryRepository extends Repository<Category> {

  Future<List<Category>> getAll() async {
    var database = await getDataBaseAsync();
    List<Map> list = await database.rawQuery('SELECT * FROM $tableCategory');
    var result = list.map((map) => new Category.fromMap(map)).toList();

    return result;
  }

  Future<Category> insert(Category category) async {
    var database = await getDataBaseAsync();
    
    var map = category.toMap();
    /*
    print(map);
    Map<String, dynamic> mapp = map;
    print(mapp);
    */

    category.id = await database.insert(tableCategory, map);
    return category;
  }

}
import 'dart:async';

import 'package:flutter/material.dart';
import 'package:spender/database/models.dart';
import 'package:spender/database/dao.dart';
import 'package:spender/pages/categoryPages.dart';

class MyHomePage extends StatefulWidget {
  MyHomePage({Key key, this.title}) : super(key: key);

  final String title;

  @override
  _MyHomePageState createState() => new _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {

  var _collection = new List<Category>();
  var dao = new Dao();

  @override
  void initState () {
    super.initState();

    initDataAsync();
  }

  Future initDataAsync() async {
    try {
      var categories = await dao.categoryRepository.getAll();

      if(categories != null) { 
        setState(() {
          _collection.addAll(categories);
        });
      }
    } catch (error) {
      print(error);
    }
  }

  @override
  Widget build(BuildContext context) {
    return new Scaffold(
      appBar: new AppBar(
        title: new Text(widget.title),
      ),
      body: new ListView.builder(
        itemBuilder: (BuildContext context, int index) => new CategoryItem(_collection[index]),
        itemCount: _collection.length,
      ),
      floatingActionButton: new FloatingActionButton(
        onPressed: () async {
          
          var category = await Navigator.push(
            context,
            new MaterialPageRoute(builder: (context) => new CreateCategoryPage()),
          );

          if(category is Category){
            setState(() {
              _collection.add(category);
            });
          }
        },
        tooltip: 'Create category',
        child: new Icon(Icons.add),
      ),
    );
  }
}

class CategoryItem extends StatelessWidget {
  const CategoryItem(this.category);

  final Category category;

  @override
  Widget build(BuildContext context) {
    return new ListTile(title: new Text(category.title));
  }
}
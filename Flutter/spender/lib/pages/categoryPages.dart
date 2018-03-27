import 'package:flutter/material.dart';
import 'package:spender/database/dao.dart';
import 'package:spender/database/models.dart';

class CreateCategoryPage extends StatelessWidget {
  var dao = new Dao();

  String _title;

  @override
  Widget build(BuildContext context) {
    return new Scaffold(
      appBar: new AppBar(
        title: new Text("Create category"),
      ),
      body: new Column(
        children: <Widget>[
          new ListTile(
            leading: const Icon(Icons.title),
            title: new TextField(
              decoration: new InputDecoration(
                hintText: "Title"
              ),
              onChanged: (newValue) {
                _title = newValue;
              }
            ),
          ),
          new BottomAppBar(
            child:  new RaisedButton(
              onPressed: () async {

                var category = new Category();
                category.title = _title;

                var newCategory = await dao.categoryRepository.insert(category);

                if(newCategory is Category) {
                  Navigator.pop(context, newCategory);
                }
              },
              child: new Text('Crete'),
            ),
          )
        ],
      ),
    );
  }
}
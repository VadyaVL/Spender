import 'package:flutter/material.dart';
import 'editCategoryPage.dart';

class MyHomePage extends StatefulWidget {
  MyHomePage({Key key, this.title}) : super(key: key);

  // This widget is the home page of your application. It is stateful, meaning
  // that it has a State object (defined below) that contains fields that affect
  // how it looks.

  // This class is the configuration for the state. It holds the values (in this
  // case the title) provided by the parent (in this case the App widget) and
  // used by the build method of the State. Fields in a Widget subclass are
  // always marked "final".

  final String title;

  @override
  _MyHomePageState createState() => new _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {

  var _collection = new List<Category>();

  void _createCategory(Category category) {
    setState(() {
      _collection.add(category);
    });
  }

  @override
  Widget build(BuildContext context) {
    // This method is rerun every time setState is called, for instance as done
    // by the _incrementCounter method above.
    //
    // The Flutter framework has been optimized to make rerunning build methods
    // fast, so that you can just rebuild anything that needs updating rather
    // than having to individually change instances of widgets.
    return new Scaffold(
      appBar: new AppBar(
        // Here we take the value from the MyHomePage object that was created by
        // the App.build method, and use it to set our appbar title.
        title: new Text(widget.title),
      ),
      body: new ListView.builder(
        itemBuilder: (BuildContext context, int index) => new CategoryItem(_collection[index]),
        itemCount: _collection.length,
      ),
      floatingActionButton: new FloatingActionButton(
        onPressed: () {
          /*Navigator.push(
            context,
            new MaterialPageRoute(builder: (context) => new EditCategoryPage()),
          );*/
          _createCategory(new Category(_collection.length.toString()));
        },
        tooltip: 'Increment',
        child: new Icon(Icons.add),
      ), // This trailing comma makes auto-formatting nicer for build methods.
    );
  }
}

class Category {
  Category(this.title);
  final String title;
}

class CategoryItem extends StatelessWidget {
  const CategoryItem(this.category);

  final Category category;

  @override
  Widget build(BuildContext context) {
    return new ListTile(title: new Text(category.title));
  }
}
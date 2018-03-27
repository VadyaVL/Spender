import 'database.dart';

class Category {
  int id;
  String title;

  Category();

  Category.ddd(Map map) {
    id = map[columnId];
    title = map[columnTitle];
  }

  Category.fromMap(Map map) {
    id = map[columnId];
    title = map[columnTitle];
  }

  Map toMap() {
    Map map = {columnTitle: title};
    if (id != null) {
      map[columnId] = id;
    }
    return map;
  }
}

class Job {
  int id;
  DateTime startDate;
  DateTime endDate;

  Job();

  Map toMap() {
    Map map = {columnStartDate: startDate, columnEndDate: endDate};
    if (id != null) {
      map[columnId] = id;
    }
    return map;
  }

  Job.fromMap(Map map) {
    id = map[columnId];
    startDate = map[columnStartDate];
    endDate = map[columnEndDate];
  }
}
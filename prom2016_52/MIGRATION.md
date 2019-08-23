# Для инициализации миграции

```
python migrate.py db init
```

# Для первой миграции

```
python migrate.py db migrate
```

# Для перехода на новую версию

```
python migrate.py db upgrade
```

# Справка 

```
python migrate.py db --help
```

## Перед миграцией отредактируем функции upgrade/downgrade. Они соответственно 
будут проводить изменения при выполнении данного скрипта миграции.

## Самые частоиспользуемые конструкции:
### Создание таблицы
```python
import alembic as op
import sqlalchemy as sa
op.create_table(
        'table_name',
        sa.Column('id', sa.Integer, primary_key=True),
        sa.Column('name', sa.String(50), nullable=False),
        sa.Column('description', sa.Unicode(200)),
    )
```
### Удаление таблицы
```python
op.drop_table('table_name')
```
### Создание столбца
```python
op.add_column('table_name', sa.Column('column_name', sa.DateTime))
```
### Удаление столбца
```python
op.drop_column('table_name', 'column_name')
```
import psycopg2

def checkPrimaryKey():
    try:
        connection = psycopg2.connect(user = "postgres",
                                      password = "admin",
                                      host = "127.0.0.1",
                                      port = "5432",
                                      database = "projekt")

        cursor = connection.cursor()
        
        # Pobranie nazw tabel
        cursor.execute("""SELECT table_name FROM information_schema.tables
           WHERE table_schema = 'public' AND table_type = 'BASE TABLE';""")
        tables_name = cursor.fetchall()
        for i in range(len(tables_name)):
            tables_name[i] = tables_name[i][0]
        
        # Pobranie kolumn składających się na PRIMARY KEY
        records = []
        for table_name in tables_name:
            cursor.execute("""SELECT a.attname, format_type(a.atttypid, a.atttypmod) AS data_type
                                FROM   pg_index i
                                JOIN   pg_attribute a ON a.attrelid = i.indrelid
                                                     AND a.attnum = ANY(i.indkey)
                                WHERE  i.indrelid = '{}'::regclass
                                AND    i.indisprimary""".format(table_name))
            records.append(cursor.fetchall())        
        ids_name = []
        for record in records:
            ids = []
            for a in record:
                ids.append(a[0])
            ids_name.append(ids)

        connected_key_values = []
        for i in range(len(tables_name)):
            if len(ids_name[i]) == 1:
                cursor.execute("""SELECT CASE WHEN count(distinct {})= count({})
                    THEN 'PRIMARY KEY in table {} is UNIQUE' 
                    ELSE 'PRIMARY KEY in table {} is NOT UNIQUE' END
                    FROM {};""".format(ids_name[i][0], ids_name[i][0], tables_name[i], tables_name[i], tables_name[i]))
                print(cursor.fetchone()[0])
            else: # np. gdy mamy tebaelę pomocniczą w relacji wiele do wielu
                value = 0
                cursor.execute("SELECT * FROM {}".format(tables_name[i]))
                records = cursor.fetchall()
                if len(records) == len(set(records)):
                    print('PRIMARY KEY in table {} is UNIQUE'.format(tables_name[i]))
                else:
                    print('PRIMARY KEY in table {} is NOT UNIQUE'.format(tables_name[i])) 
                
        
    except (Exception, psycopg2.Error) as error :
        print ("Error while connecting to PostgreSQL", error)
    finally:
            if(connection):
                cursor.close()
                connection.close()
            

def checkForeignKey():
    try:
        connection = psycopg2.connect(user = "postgres",
                                      password = "admin",
                                      host = "127.0.0.1",
                                      port = "5432",
                                      database = "projekt")

        cursor = connection.cursor()

        # Pobranie nazw tabel
        cursor.execute("""SELECT table_name FROM information_schema.tables
           WHERE table_schema = 'public' AND table_type = 'BASE TABLE';""")
        tables_name = cursor.fetchall()
        for i in range(len(tables_name)):
            tables_name[i] = tables_name[i][0]

        # Wydobycie z bazy tych tabel, które posiadają klucz obcy, nazwy tych kluczy oraz nazwy tabel obcych i ich kolumn
        for table_name in tables_name:
            cursor.execute("""
            SELECT
                tc.table_name,
                kcu.column_name, 
                ccu.table_name AS foreign_table_name,
                ccu.column_name AS foreign_column_name 
            FROM 
                information_schema.table_constraints AS tc 
                JOIN information_schema.key_column_usage AS kcu
                  ON tc.constraint_name = kcu.constraint_name
                  AND tc.table_schema = kcu.table_schema
                JOIN information_schema.constraint_column_usage AS ccu
                  ON ccu.constraint_name = tc.constraint_name
                  AND ccu.table_schema = tc.table_schema
            WHERE tc.constraint_type = 'FOREIGN KEY' AND tc.table_name='{}';
            """.format(table_name))
            records = cursor.fetchall()
            tables_name = []
            columns_name = []
            foreign_tables_name = []
            foreign_columns_name = []
            for record in records:
                tables_name.append(record[0])
                columns_name.append(record[1])
                foreign_tables_name.append(record[2])
                foreign_columns_name.append(record[3])

            # Sprawdzenie na każdej tabeli, czy klucz obcy to null lub czy znajduje się w tabeli obcej
            for i in range(len(tables_name)):

                # Wydobycie wszystkich wartości klucza z obcych tabel, aby sprawdzić, czy klucz obcy,
                # pobrany z głównej tabeli, znajduje sie tam
                cursor.execute('SELECT DISTINCT {} FROM {};'.format(foreign_columns_name[i], foreign_tables_name[i]))
                values = cursor.fetchall()
                for j in range(len(values)):
                    values[j] = values[j][0]

                # Wydobycie wszystkich wartości z kolumny z obcym kluczem, aby sprawdzić, czy znajduje się on
                # w tabeli obcej
                cursor.execute('SELECT DISTINCT {} FROM {};'.format(columns_name[i], tables_name[i]))
                foreign_keys = cursor.fetchall()
                for j in range(len(foreign_keys)):
                    foreign_keys[j] = foreign_keys[j][0]

                # Sprawdzenie zgodności kluczy
                is_good = 1
                for foreign_key in foreign_keys:
                    if foreign_key in values:
                        pass
                    else:
                        print("FOREIGN KEY {} which is in table {} in not in table {}".format(foreign_key, tables_name[i], foreign_tables_name[i]))
                        is_good = 0

                if is_good:
                    print("All FOREIGN KEY from table {} is in FOREIGN TABLE {}".format(tables_name[i],foreign_tables_name[i] ))

    except (Exception, psycopg2.Error) as error :
        print ("Error while connecting to PostgreSQL", error)
    finally:
            if(connection):
                cursor.close()
                connection.close()
                
print()
checkPrimaryKey()
print()
checkForeignKey()
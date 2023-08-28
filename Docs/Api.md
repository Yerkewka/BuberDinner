# API Docs

## Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
  "firstName": "Yerkebulan",
  "lastName": "Serikbayev",
  "email": "yerkebulan.serikbayev@gmail.com",
  "password": "password"
}
```

```js
200 OK
```

#### Register Response

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "firstName": "Yerkebulan",
  "lastName": "Serikbayev",
  "email": "yerkebulan.serikbayev@gmail.com",
  "token": "token"
}
```

## Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
  "email": "yerkebulan.serikbayev@gmail.com",
  "password": "password"
}
```

```js
200 OK
```

#### Login Response

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "firstName": "Yerkebulan",
  "lastName": "Serikbayev",
  "email": "yerkebulan.serikbayev@gmail.com",
  "token": "token"
}
```

# Key

## Client ID 

สร้างจากการ register app ใน Azure AD

```
38478b47-0715-4ce9-8d56-90ff0d503ce4
```

## Client Secret

สร้างในส่วนของ Security ของ App ที่ register ใน Azure AD

```
8dKY.1g5rdb_oLJ91.OvGLe4rK5WIP-cKu
```


### ส่ง request ไปที่ authen server เพื่อ login 

https://login.microsoftonline.com/common/oauth2/v2.0/authorize?client_id=38478b47-0715-4ce9-8d56-90ff0d503ce4&response_type=code&scope=user.read

จะได้ code กลับมาใน URL เราจะเอาส่วนนี้ไปใช้ในการของ token bearer

http://localhost/?code=M.R3_BAY.358e2ad9-cf16-45b7-7927-edc36348aa3b


## Code

ได้จากการ authen

```
M.R3_BAY.358e2ad9-cf16-45b7-7927-edc36348aa3b
```
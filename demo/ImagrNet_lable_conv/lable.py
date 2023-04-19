import os

 
#以 utf-8 的编码格式打开指定文件
f = open("lable.txt",encoding = "utf-8")

with open(r'ImagrNet_lable.txt', 'w') as ff:
    #输出读取到的数据
    s = f.read(1)
    ss = ""
    while s:
        # print(s)
        if s=='\'':
            
            s = f.read(1)
            while s!='\'':
                ss+=s
                s = f.read(1)
                if s=='\'':
                    print(ss)
                    ff.write(ss+"\n")
                    ss = ""
                    s = f.read(1)
                    break
        else:
            s = f.read(1)

    #关闭文件
    f.close()

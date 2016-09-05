require "Define"
require "CtrlManager"
require "pbc/protobuf"

--主入口函数。从这里开始lua逻辑
function Main()					
	 print("hello sb")

    -- ResisterNetEvent(1,"Main","Main")
    -- TestSend()
    registerProtobuf("addressbook.pb")

    CtrlManager.InitCtrlList()
    --CtrlManager.InitViewPanels()

    
    local ctrl = CtrlManager.GetCtrl(CtrlNames.Test)
    if ctrl ~= nil then
        ctrl.Awake()
    end
    
    pbc()
end

--场景切换通知
function OnLevelWasLoaded(level)
	Time.timeSinceLevelLoad = 0   
end

--供测试发送网络数据
function TestSend()
    local buffer = ByteBuffer.New()
    buffer:WriteShort(1)
    SendMessage(buffer)
end

-- 注册lua网络回调事件的总接口，处理服务器下发的消息
function ResisterNetEvent(id,Module,func)
    NetMgr:BindLuaCallback(id,Module,func)
end

--  发送网络消息的总接口   参数ByteBuffer
function SendMessage(args)
    NetMgr:SendMessage(args)
end


--注册pb文件 
function  registerProtobuf(filename)
    print("正在注册pb文件 ： " .. filename)

    local addr = io.open(UnityEngine.Application.dataPath .. "/Lua/pbc/"..filename,"rb")
    local buffer = addr:read "*a"
    addr:close()
    protobuf.register(buffer)
end


--序列化测试
function pbc()

    local addressbook = 
    {
        name = "Alice",
        id = 12345,
        phone = 
        {
            {number = "11111"},
            {number = "22222",type = "WORK"},
        }
    }

    local code = protobuf.encode("tutorial.Person",addressbook)
    local buffer = ByteBuffer.New()
    buffer:WriteBuffer(code)
    SendMessage(buffer)

    OnPbc(code)
end

--反序列化测试
function OnPbc(data)

    local decode = protobuf.decode("tutorial.Person",data)

    print(decode.name)
    print(decode.id)
    for k,v in ipairs(decode.phone) do
        print("\t"..v.number,v.type)
    end
end

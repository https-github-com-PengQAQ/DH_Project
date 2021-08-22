

GameModel = BaseClass("GameModel",Observer)
local this = GameModel

function GameModel.GetInstance( ... )
	-- body
	this.life = 5
	this.coin = 200

	LogUtils.info("GameModel")
	return this
end


--数据层在接受到通知后变化
function GameModel.Notify(data)
	-- body
	
	if data[1] == 0 then
		this.LifeChange(data[2])
	elseif data[1] == 1 then
		this.CoinChange(data[2])
	else
		this.AbilityChange(data[2])
	end
end

--改变生命值
function GameModel.LifeChange(data)
	-- body
	LogUtils.info("kkkkkkkkkkkk")
	LogUtils.info(data)
	this.life = this.life + data

	--更新后通知view层刷新
	GameView.RefreshLife()
end

--改变金币
function GameModel.CoinChange(data)
	-- body
	this.coin = this.coin + data

	--更新后通知view层刷新
	GameView.RefreshCoin()
end

function GameModel.AbilityChange(data)
	-- body

end


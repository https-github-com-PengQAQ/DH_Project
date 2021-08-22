--
-- Author: cm_wang
-- Date: 2015-07-22 16:21:11
--
local FileOpt = {}

local Directory = CS.System.IO.Directory
local File = CS.System.IO.File

function FileOpt.split(str, delimiter)
    if not delimiter then 
    	return false 
    end
    local pos, arr = 0, {}
    for st, sp in function() return string.find(str, delimiter, pos, true) end do
        table.insert(arr, string.sub(str, pos, st - 1))
        pos = sp + 1
    end
    table.insert(arr, string.sub(str, pos))
    return arr
end

function FileOpt.mkdir(fname)
    if not Directory.Exists(fname) then
        Directory.CreateDirectory(fname)
    end
end


function FileOpt.readFile(fname)
    local rfile = io.open(fname, "rb")
    if not rfile then
        print("open file failed:", fname)
        return nil
    end
    local content = rfile:read("*all")
    io.close(rfile)
    return content
end

function FileOpt.writeFile(data, fname)
    local pos = #fname
    while string.sub(fname, pos, pos) ~= "/" do
        pos = pos -1
        if pos <= 1 then
            print("path have no char / :", fname)
            return false
        end
    end
    local fpath = string.sub(fname, 1, pos)
    --print("fpath dir:",fpath)
    FileOpt.mkdir(fpath)
    local wfile = io.open(fname, "wb")
    if not wfile then
        print("create file failed:", fname)
        return false
    end
    wfile:write(data)
    wfile:flush()
    io.close(wfile)

    return true
end

function FileOpt.cpfile(srcfile, dstfile)
    local content = FileOpt.readFile(srcfile)
    if content then
        local ret = FileOpt.writeFile(content, dstfile)
        return ret
    end
    return false
end

function FileOpt.rmfile(fname)
    if Directory.Exists(fname) then
        return FileOpt.rmdir(fname) 
    else
        os.remove(fname)
        return true
    end
    return false 
end

--ignore:如果dest_dir存在同名文件,是否忽略
function FileOpt.cpdir(src_dir, dst_dir,ignore)
    if not Directory.Exists(src_dir) then
        print("cp src_dir is not existed!")
        return
    end
    if not Directory.Exists(dst_dir) then
        FileOpt.mkdir(dst_dir)
    end

    local subFiles = Directory.GetFiles(src_dir)
    local subDirs = Directory.GetDirectories(src_dir)

    --先复制文件
    if subFiles then
        for i=0,subFiles.Length - 1 do
            local path = subFiles:GetValue(i)
            local name = string.sub(path, #src_dir+1)
            local destPath = dst_dir .. name
            if FileOpt.fileExists(destPath) then
                if not ignore then
                    FileOpt.cpfile(path, destPath)
                end
            else
                FileOpt.cpfile(path, destPath)
            end
        end
    end

    --再复制目录
    if subDirs then
        for i=0,subDirs.Length - 1 do
            local path = subDirs:GetValue(i)
            local name = string.sub(path, #src_dir+1)
            if not (name == "." or name == "..") then
                local destPath = dst_dir .. name
                FileOpt.cpdir(path, destPath)
            end
        end
    end
end

function FileOpt.rmdir(fname)
    if Directory.Exists(fname) then
        Directory.Delete(fname, true)
        return true
    end
    return false
end

function FileOpt.fileExists(path)
    return File.Exists(path)
end

function FileOpt.dirctoryExists(path)
    return Directory.Exists(path)
end

return FileOpt

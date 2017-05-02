using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;

namespace QuizRoulette.Web.Services
{
    public interface IAssetPathService
    {
        string GetPath(string name);
    }

    public class AssetPathService : IAssetPathService
    {
        private object _lock = new object();
        private DateTime _lastUpdateTime = DateTime.MinValue;
        private string _manifestFilePath;
        private IUrlHelper _urlHelper;

        private Dictionary<string, string> _assetPaths;

        public AssetPathService(IUrlHelper urlHelper, string path)
        {
            _urlHelper = urlHelper;
            _manifestFilePath = path;
            Console.WriteLine($"path: {path}");
            UpdatePaths();
        }

        public string GetPath(string name)
        {
            UpdatePaths();
            System.Console.WriteLine($"Getting asset: {name}");
            if (!_assetPaths.ContainsKey(name))
            {
                throw new FileNotFoundException(name);
            }
            System.Console.WriteLine($"Asset path: {_assetPaths[name]}");

            return _urlHelper.Content(_assetPaths[name]);
        }

        private void UpdatePaths()
        {
            var fileInfo = new FileInfo(_manifestFilePath);
            if (fileInfo.LastWriteTime > _lastUpdateTime)
            {
                lock (_lock)
                {
                    var content = File.ReadAllText(_manifestFilePath);
                    _assetPaths = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                    _lastUpdateTime = fileInfo.LastWriteTime;
                }
            }
        }
    }
}
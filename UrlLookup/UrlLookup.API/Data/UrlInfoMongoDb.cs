using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlLookup.API.Models;

namespace UrlLookup.API.Data
{
    public class UrlInfoMongoDb : IUrlInfoDatabase
    {
        private IMongoCollection<UrlInfo> _urlListCollection;

        public UrlInfoMongoDb(IMongoClient client)
        {
            var database = client.GetDatabase("malicious_urls_db");
            _urlListCollection = database.GetCollection<UrlInfo>("url_list");
        }

        public void Create(UrlInfo urlInfo)
        {
            throw new NotImplementedException();
        }

        public UrlInfo ReadById(string id)
        {
            throw new NotImplementedException();
        }

        public UrlInfo ReadByUrlRequest(string request)
        {
            UrlInfo result = _urlListCollection.Find(s => s.UrlName == "nifty.com/libero/non/mattis/pulvinar/nulla/pede.json?non=consequat&ligula=varius&pellentesque=integer&ultrices=ac&phasellus=leo&id=pellentesque&sapien=ultrices&in=mattis&sapien=odio&iaculis=donec&congue=vitae&vivamus=nisi&metus=nam&arcu=ultrices&adipiscing=libero&molestie=non&hendrerit=mattis&at=pulvinar&vulputate=nulla&vitae=pede&nisl=ullamcorper&aenean=augue&lectus=a&pellentesque=suscipit&eget=nulla&nunc=elit&donec=ac&quis=nulla&orci=sed&eget=vel&orci=enim&vehicula=sit&condimentum=amet&curabitur=nunc&in=viverra&libero=dapibus&ut=nulla&massa=suscipit&volutpat=ligula&convallis=in&morbi=lacus&odio=curabitur&odio=at&elementum=ipsum&eu=ac&interdum=tellus&eu=semper&tincidunt=interdum&in=mauris&leo=ullamcorper&maecenas=purus&pulvinar=sit").FirstOrDefault<UrlInfo>();

            return result;
        }
    }
}

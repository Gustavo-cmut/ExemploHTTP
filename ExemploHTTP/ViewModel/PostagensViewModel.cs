﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using ExemploHTTP.Models;

namespace ExemploHTTP.ViewModels
{
    partial class PostagensViewModel : ObservableObject
    {
        private readonly RestService _restService;

        [ObservableProperty]
        private ObservableCollection<Postagem> _postagens = new ObservableCollection<Postagem>();

        public PostagensViewModel()
        {
            _restService = new RestService();
            GetPostagensAsyncCommand = new Command(async () => await GetPostagensAsync());
        }

        public ICommand GetPostagensAsyncCommand { get; }

        public async Task GetPostagensAsync()
        {
            Postagens = await _restService.GetPostagensAsync();
        }
    }
}

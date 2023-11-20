@extends('adminLayout')
@section('adminContent')
 
<div class="table-agile-info">
<div class="panel panel-default">
    <div class="panel-heading">
      <h2 class="title-list">@lang('dic.List') @lang('dic.Ruling')  @lang('dic.of')  @lang('dic.Manuscript')</h2>
      @include('admin.message')
      <a href="{{URL::to('/rulings/create')}}" name = "add" class="btn btn-info">@lang('dic.Add') @lang('dic.new') @lang('dic.Ruling')</a>
    </div>
<?php
     $admin_level = Session::get('admin_level');
?>      
    <hr/>
    <div class="table-responsive">
      <table class="table table-striped b-t b-light">
        <thead>
          <tr >
            <th class="list">@lang('dic.Ruling') @lang('dic.English')</th>
            <th class="list">@lang('dic.Ruling') @lang('dic.French')</th>
            <th class="list">@lang('dic.Ruling') @lang('dic.Chinese')</th>
            
            <th style="width:30px;"></th>
            <th style="width:30px;"></th>
          </tr>
        </thead>
        <tbody>
            @forelse ($rulings as $Ruling)
             
            <tr>
            <td><span class="text-ellipsis">{{$Ruling->RulingEn}}</span></td>
            <td><span class="text-ellipsis">{{$Ruling->RulingFr}}</span></td>
            <td><span class="text-ellipsis">{{$Ruling->RulingZh}}</span></td>
                  
            <td>
              <a href="{{URL::to('/rulings/edit/'.$Ruling->id)}}" class="active styling-edit" ui-toggle-class="">
                
                <i class="fa fa-pencil-square-o text-success text-active">@lang('dic.Edit')</i></a>
              </td>
              <td>
  @if($admin_level == 3 || $admin_level == 2 )  

            
              <a onclick="return confirm('Do you want to delete Ruling?')" href="{{URL::to('rulings/delete/'.$Ruling->id)}}" class="active styling-edit" ui-toggle-class="">
                <i class="fa fa-times text-danger text">@lang('dic.Delete')</i>
              </a>
  @else 
              &#127914;
  @endif      
            </td>
          </tr> 
          @empty
          <p>No @lang('dic.Ruling')</p>
          @endforelse                  
        </tbody>
      </table>
    </div>
   <footer class="panel-footer">
      
   </footer>
  </div>
</div>
 

@endsection
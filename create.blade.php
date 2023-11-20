@extends('adminLayout')
@section('adminContent')
<div class="row">
<hr/>
<div class="col-lg-12">
    <section class="panel">
        <header class="panel-heading">
            <h2 class="title-list">@lang('dic.Ruling') </h2>
            <hr/>
            <h3 class="title-Add">@lang('dic.Add') @lang('dic.Ruling')</h3>
        </header>
         @include('admin.message')
        <div class="panel-body">
            <div class="position-center">
                <form role="form" action="{{URL::to('/rulings')}}" method="post" enctype="multipart/form-data">
                   {{csrf_field()}} 
               @include('admin.Ruling.formCreate')
                
                <button type="submit" name = "saveRuling" class="btn btn-info">@lang('dic.Save') @lang('dic.Ruling')</button>
                 <a href="{{URL::to('/rulings')}}" name = "return" class="btn btn-info">@lang('dic.Return')</a>
            </form>
            </div>
        </div>
    </section>
</div>
</div>

@endsection